using System;
using System.Text.RegularExpressions;

namespace dataTest
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            
            SaveManager saveManager = new SaveManager(@"C:\k-on","黄色チャート",300);
            //saveManager.AddToSave(1,new memoryObject("あかさたな",new DateTime(2021,4,16)));
            saveManager.NumberOfQuestionChecker();
            Console.WriteLine(saveManager.GetSaveString(1));
            var list = saveManager.GetSave(1);
            
            Console.WriteLine("-----------------------------");
            foreach (var memoryObjects in list)
            {
                Console.WriteLine($"{memoryObjects.Comment}:{memoryObjects.DateTime.ToString()}");
            }
            
        }

    }
}