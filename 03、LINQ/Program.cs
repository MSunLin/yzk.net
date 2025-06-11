namespace _03_LINQ
{
    delegate void ResultText(string text);
    internal class Program
    {
        /* 1、委托
         * 
         */
        static void Main(string[] args)
        {
            //创建一个委托实例，并指向一个方法，需要注意参数和返回值必须一致
            ResultText rt = ShowText;
            rt("sasfsa f");

            //.Net中定义了泛型委托Func【有返回值】和Action【无返回值】，一般情况下不用自定义委托类型
            Action<string> action = ShowText;
            action("我用是的Action");

            Func<int, int, int> func = Sum;
            Console.WriteLine("我是Func"+func(1,2).ToString());
        }
        static void ShowText(string text)
        {
            Console.WriteLine(text);
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }


    }
}
