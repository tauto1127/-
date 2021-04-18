using System.Windows;

namespace 参考書進行状況記録ソフト
{
    public partial class BookWindow : Window
    {
        public BookWindow(Book book)
        {
            SaveManager saveManager = new SaveManager(book);
            //var questionList = saveManager.GetSave();
            InitializeComponent();
        }
    }
}