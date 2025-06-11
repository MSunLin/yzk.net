using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;

namespace _08_DI的传染性
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ILog, ConsoleLog>(); // 注册ILog接口的实现类ConsoleLog，使用Scoped生命周期
            services.AddScoped<Controller>();
            services.AddScoped<IConfig, configImpl>(); // 注册IConfig接口的实现类configImpl，使用Scoped生命周期
            services.AddScoped<IStorage, FileStorage>(); // 注册IStorage接口的实现类FileStorage，使用Scoped生命周期

            // 构建服务提供者
            using (var sp = services.BuildServiceProvider())
            {
                var c = sp.GetRequiredService<Controller>();
                // 获取Controller实例
                c.Test(); // 调用Controller的Test方法
            }
            Console.ReadLine();
        }

        class Controller
        { 
            private readonly ILog log;
            private readonly IStorage storage;

            public Controller(ILog log, IStorage storage)
            {
                this.log = log;
                this.storage = storage;
            }
            public void Test()
            {
                log.Log("开始上传");
                this.storage.Save("file.txt", "文件内容");
                log.Log("上传完成");
            }
        }

        interface ILog
        { 
            public void Log(string message);
        }
        class ConsoleLog : ILog
        {
            public void Log(string message)
            {
                Console.WriteLine($"日志:{message}");
            }
        }

        interface IConfig
        { 
            public string GetConfig(string key);
        }

        class configImpl : IConfig
        {
            public string GetConfig(string key)
            {
                return "配置项:" + key;
            }
        }

        interface IStorage
        { 
            public void Save(string key, string value);
        }

        class FileStorage : IStorage
        {
            private readonly IConfig config;
            public FileStorage(IConfig config)
            {
                this.config = config;
            }

            public void Save(string key, string value)
            {
                string configValue = config.GetConfig(key);
                Console.WriteLine($"向服务器{configValue},文件名{value}");
            }
        }
    }
}
