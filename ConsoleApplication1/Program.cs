using System;
using System.IO;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string homePath;
            string filepathhhh = Console.ReadLine();
            fdljsl aaa = new fdljsl(@"C:\3D",filepathhhh);
        }
    }

    class fdljsl
    {
        private string homePath;
        public fdljsl(string homePath, string filePath)
        {
            this.homePath = homePath + @"\";
            Console.WriteLine(Directory.Exists($"{this.homePath}{filePath}"));
        }
    }
}