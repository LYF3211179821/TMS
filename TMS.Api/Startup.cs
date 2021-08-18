using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.Common.Jwt;
using TMS.Common.Log;
using TMS.Common.SQLInject;
using TMS.IRepository;
using TMS.IRepository.User;
using TMS.Repository.BasicInformation;
using TMS.Repository.User;
using TMS.Service.BasicInformation;
using TMS.Service.User;

namespace TMS.Api
{
    /// <summary>
    /// Startup ��
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region ע��Dapper����
            //����sqlserver
            services.AddDapper("SqlDb", m =>
            {
                m.ConnectionString = Configuration.GetConnectionString("SqlServer");
                m.DbType = DbStoreType.SqlServer;
            });
            #endregion

            #region �쳣������
            //��ӵ����� �����Ĵ�ȡ��
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //��ӵ����� NLog������
            services.AddSingleton<INLogHelper, NLogHelper>();

            //���ó�ȫ�ֵķ���
            //ģ����ͼ��������ӹ�����(CustomExceptionFilter)
            //AddControllers����ֻ��ӿ�����������
            services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionFilter)));
            #endregion

            #region SQLע��
            //�������ϼ�SQLע�������
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomSQLInjectFilter>();
            });

            //services.AddControllers();
            #endregion

            #region JWT����
            //��ȡjwt������
            var jwtTokenConfig = Configuration.GetSection("JWTConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            //ע��JwtTokenConfig���÷���
            services.Configure<JwtTokenConfig>(Configuration.GetSection("JWTConfig"));

            services.AddTransient<ITokenHelper, TokenHelper>();

            //���������֤����
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //��֤ģʽ
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    //��ѯģʽ
            })
            .AddJwtBearer(
                x =>
                {
                    //��JwtBearer��������
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        //Token��֤����
                        ValidateIssuer = true,  //�Ƿ���֤Issuer
                        ValidIssuer = jwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.IssuerSigningKey)),
                        ValidateAudience = true,
                        ValidAudience = jwtTokenConfig.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)  //��token����ʱ����֤������ʱ��
                    };
                }
            );
            #endregion

            #region Swagger��֤������
            //ָ����Microsoft.AspNetCore.Mvc.mvcopions���õ�����ʱ��Ϊ�İ汾�����ԡ�
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS.Api", Version = "v1", Description = "TMS.Api" });
                // Ϊ Swagger ����xml�ĵ�ע��·��
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
                c.IncludeXmlComments(xmlPath, true);

                //����AuthorizeȨ�ް�ť
                c.AddSecurityDefinition("JWTBearer", new OpenApiSecurityScheme()
                {
                    Description = "���Ƿ�ʽһ(ֱ�����������������֤��Ϣ������Ҫ�ڿ�ͷ���Bearer) ",
                    Name = "Authorization",         //jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,  //jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                //����JwtBearer��֤��ʽ��
                //options.AddSecurityDefinition("JwtBearer", new OpenApiSecurityScheme()
                //{
                //    Description = "���Ƿ�ʽ��(JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�)",
                //    Name = "Authorization",//jwtĬ�ϵĲ�������
                //    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                //    Type = SecuritySchemeType.ApiKey
                //});

                //����һ��Scheme��ע�������IdҪ������AddSecurityDefinition�еĲ���nameһ��
                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "JWTBearer",   //��������������һ��
                        Type = ReferenceType.SecurityScheme
                    }
                };
                //ע��ȫ����֤�����еĽӿڶ�����ʹ����֤��
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { scheme, Array.Empty<string>() }
                });
            });
            #endregion

            #region ����
            //���cors ���� ���ÿ���������
            services.AddCors(options => options.AddPolicy("cor",
            builder =>
            {
                builder.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                  .AllowCredentials();
            }));
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            #region Nlog
            //���NLog
            loggerFactory.AddNLog();
            //��������
            NLog.LogManager.LoadConfiguration("NLog.config");
            //�����Զ�����м��
            app.UseLog();
            #endregion

            #region  Swagger����
            //�����ж��ǿ��������������л���������������������ʽ�����ļ��
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS.Api v1"));
            }
            #endregion

            #region ʹ��ע������
            //���������ļ����ϴ���
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            //·��
            app.UseRouting();
            //�������������֤�м��
            app.UseAuthentication();
            //��Ȩ
            app.UseAuthorization();
            //����Cors����
            app.UseCors("cor");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }

        #region ʹ��AutoFac ����ע��
        //ConfigureContainer��������ֱ��ע��ĵط�

        //ʹ��AutoFac������ConfigureServices֮�����У����

        //�˴���������ConfigureServices�н��е�ע�ᡣ

        //��Ҫ���������������������ɵġ�
        /// <summary>
        /// ConfigureContainer��������ֱ��ע��ĵط�
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //������ֱ����AutoFacע�����Լ��Ķ�������Ҫ
            //����builder.Populate(),�ⷢ����AutofacServiceProviderFactory��
            builder.RegisterAssemblyTypes(typeof(VehicleManagementRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(VehicleManagementService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
        #endregion
    }


}
