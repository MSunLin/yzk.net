namespace _04_Lambda表达式
{
   

    internal class Program
    {
        /* 笔记：1、委托变量不近可以指向普通方法，还可以指向匿名方法
         *       2、匿名方法可以写成lambda表达式，可以省略   参数数据类型，因为编译能根据委托类型推断出参数类型，用法：=>引出方法体
         *       3、lambda表达式可以省略方法体的{}，如果只有一行代码，可以省略return关键字
         *          
         */
        static void Main(string[] args)
        {
            //委托变量不近可以指向普通方法，还可以指向匿名方法
            Func<int, int, string> f1 = delegate (int a, int b)
            {
                return (a + b).ToString();
            };
            Console.WriteLine("f1:"+f1 (1,2));


            //2
            Func<int ,int ,string> f2 = (int c ,int d ) =>
            {
                return (c + d).ToString();
            };
            Console.WriteLine("f2:"+f2(3,5));


            //3
            Func<int, int, string> f3 = (c, d) => (c + d).ToString();
            Console.WriteLine("f3:"+f3(66,5));


            Action<string> a1 = (str) => Console.WriteLine(str);
            a1("我是Action的lambda表达式");
        }
    }
}
