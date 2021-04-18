using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace 参考書進行状況記録ソフト
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> ListBoxData1 = new ObservableCollection<string>() {"0","1","4","5","6","3","6" };
        public MainWindow()
        {
            BookManager bookManager = new BookManager();
            InitializeComponent();
            
            Console.WriteLine(BookManager.BookList[0]);
        }

        private void BookClicked(object sender, MouseButtonEventArgs e)
        {
            //SaveManager saveManager = new SaveManager((Book)BookListBox.SelectedItem);
            //MessageBox.Show(saveManager.ToString());
            /*BookWindow bookWindow = new BookWindow((Book) BookListBox.SelectedItem);
            bookWindow.Show();
            this.Close();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveManager saveManager = new SaveManager("青チャート", 60);
        }
    }
}
