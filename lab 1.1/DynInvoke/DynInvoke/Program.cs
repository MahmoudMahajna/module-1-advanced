using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            Console.WriteLine(InvokeHello(a, "A"));
            var b = new B();
            Console.WriteLine(InvokeHello(b, "B"));
            var c = new C();
            Console.WriteLine(InvokeHello(c, "C"));
        }
        static string InvokeHello(object o, string str)
        {
            return o.GetType().GetMethod("Hello").Invoke(o,new[] { str}).ToString();
        }
    }
}
