using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           /* the following code is for checking another assembly reference..
            * 
            *  AnalayzeAssembly(Assembly.LoadFile(@"C:\Users\Mahmood\Desktop\AttribDemo.exe"));
            *
            *  the result: the program cant find the types with the attribute CodeReviewAttribute. 
            *  thus the program didn't print a thing on the console.
            */ 
            var flag = AnalayzeAssembly(Assembly.GetExecutingAssembly());
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("all is approved?: Yes!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("all is appreved?: No!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static bool AnalayzeAssembly(Assembly a)
        {
            bool flag = true;
            foreach(Type t in a.GetTypes())
            {
                var attribute=(CodeReviewAttribute)Attribute.GetCustomAttribute(t,typeof(CodeReviewAttribute));
                if (attribute != null)
                    Console.WriteLine(attribute.ToString());
                if (attribute != null && !attribute.Approved)
                    flag = false; ;
            }
            return flag;
        }
    }
}
