using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace 参考書進行状況記録ソフト
{
    public partial class BookWindow : Window
    {
        private SaveManager _saveManager;
        private ObservableCollection<Question> Questions = new ObservableCollection<Question>();
        public BookWindow(Book book)
        {
            _saveManager = new SaveManager(book);
            LoadQuestion();
            InitializeComponent();
        }

        void LoadQuestion()
        {
            var lastSaveList = _saveManager.GetLastSave();
            for (int i = 1; i < _saveManager.NumberOfQuestion; i++)
            {
                Questions.Add(new Question(_saveManager.NumberOfQuestion,lastSaveList.List[i].Comment,lastSaveList.List[i].DateTime));
            }
        }
    }

    class Question
    {
        public int QuestionNumber { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public Question(int questionNumber, string comment, DateTime dateTime)
        {
            this.QuestionNumber = questionNumber;
            this.Comment = comment;
            this.DateTime = dateTime;
        }
    }
}