
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;
namespace _09_依赖注入DI案例
{
    internal class Program
    {

        //
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ILogProvider, ConsoleLogProvider>();
            services.AddScoped<IConfigService, EnvVarConfigService>();
            services.AddScoped<IMailService, MailService>();
            using (var sp = services.BuildServiceProvider())
            {
                var mailService = sp.GetRequiredService<IMailService>();
                mailService.Send("测试邮件", "114222@126.com", "这是一个测试邮件内容！");
            }
        }
    }
}
