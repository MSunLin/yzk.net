using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_IOC控制反转1
{
    internal class Class1
    {
    }
    public interface ITestService
    {
        public string Name { get; set; }
        public void PrintName();
    }

    public class TextService1 : ITestService
    {
        public string Name { get; set; }
        public void PrintName()
        {
            Console.WriteLine("hellow,my name is " + Name);
        }
    }

    public class TextService2 : ITestService
    {
        public string Name { get; set; }
        public void PrintName()
        {
            Console.WriteLine("你好，我的名字是 " + Name);
            
        }
    }
}
