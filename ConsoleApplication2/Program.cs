using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>(16);
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    list.Add(i);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}