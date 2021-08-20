using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace TMS.Api
{
    /// <summary>
    /// Program  ��
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ������  ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);//����һ��IHostBuilderʵ��hostBuilder������ͨ������
            IHost host = hostBuilder.Build();//Build()���и��������Գ�ʼ����������ֻ�ܵ���һ��
            host.Run();//����Ӧ�ó�����ֹ�����̣߳�ֱ�������ػ���

            // CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//����ע��
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                //ʹ��NLog
                .UseNLog();


    }
}
