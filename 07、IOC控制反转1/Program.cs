using Microsoft.Extensions.DependencyInjection;
namespace _07_IOC控制反转1
{
    internal class Program
    {

        static void Main(string[] args)
        { 
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ITestService,  TextService1>(); // 注册ITestService接口的实现类TextService1，使用Scoped生命周期
            services.AddSingleton(typeof(ITestService),new TextService1());

            using (ServiceProvider sp = services.BuildServiceProvider()) 
            {
                ITestService ts1 = sp.GetService<ITestService>(); // 获取ITestService接口的实现类TextService1
                ts1.Name = "张三"; // 设置Name属性
                ts1.PrintName(); // 调用PrintName方法，输出 "hellow,my name is 张三"
                ts1.GetType(); // 获取ts1的实际类型，这里是TextService1
            }
            Console.ReadLine();
        }

        static void Main1(string[] args)
        {
            /*
            这是最基本的实现方式，需要使用者非常清楚那个类实现了所需要的接口，使用起来难度较大
            ITestService t = new TextService1();
            t.Name = "张三";
            t.PrintName();
            */

            ServiceCollection services = new ServiceCollection();
            // 注册瞬时服务
            //services.AddTransient< TextService1>(); // 注册TextService1实现的ITestService接口ITestService, 
            services.AddScoped<TextService2>(); // 注册TextService2实现的ITestService接口ITestService,
            //services.AddSingleton<TextService1>(); // 注册TextService1实现的ITestService接口ITestService, 单例模式
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                /*
                TextService1 textService1 = serviceProvider.GetService<TextService1>();
                textService1.Name = "张三";
                textService1.PrintName();
                */
                using (IServiceScope scope1 = serviceProvider.CreateScope())// 创建作用域
                {
                    //在scope中获取scope1相关的对象要用scope1.ServiceProvider，不能直接用上面的serviceProvider
                    //因为serviceProvider是全局的，而scope1.ServiceProvider是当前作用域的
                    //在当前作用域中获取TextService2对象，不管获取多少次，都是同一个对象
                    TextService2 t2 = scope1.ServiceProvider.GetService<TextService2>();
                    t2.Name = "李四";
                    t2.PrintName();

                    TextService2 t3 = scope1.ServiceProvider.GetService<TextService2>();
                    t3.Name = "王五";

                    t2.PrintName();
                    Console.WriteLine("是否同一个对象"+object.ReferenceEquals(t2,t3));

                    Console.ReadKey();
                }


            }
        }
    }


}
