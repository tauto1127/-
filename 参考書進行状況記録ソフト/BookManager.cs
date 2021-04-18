using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace 参考書進行状況記録ソフト
{
    public class BookManager
    {
        public static ObservableCollection<Book> BookList { get; set; }
        public BookManager()
        {
            BookList = new ObservableCollection<Book>();
            foreach (var VARIABLE in Directory.GetDirectories(Info.homePath))
            {
                BookList.Add(new Book(VARIABLE.Replace(Info.oldHomePath + @"\",""),VARIABLE));
            }
        }
        
        
    }
}