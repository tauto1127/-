using System;
using System.IO;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            foreach (var VARIABLE in Directory.GetDirectories(@"C:\k-on"))
            {
                Console.WriteLine(VARIABLE);
            }*/
            string removestring = "おかき";
            string korekore = "あいうえおかきくけこさしすせそ";
            Console.WriteLine(korekore.Replace(removestring,""));
            
        }
    }
}