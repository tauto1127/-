using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace dataTest
{
    class SaveManager
    {
        public string homePath { get; set; }
        public string Path { get; set; }
        public int NumberOfQuestion { get; set; }
        private Regex _regex = new Regex(@"(?<Comment>.+),(?<Time>..................)");
        public SaveManager(string homePath, string bookName)
        {
            this.homePath = homePath + @"\";
            this.Path = this.homePath + bookName;
            NumberOfQuestionChecker();
        }
        
        public SaveManager(string homePath, string bookName, int NumberOfQuestions)
        {
            this.homePath = homePath + @"\";
            this.Path = this.homePath + bookName;
            if (BookExistCheck(bookName)) { CreateSave(bookName, NumberOfQuestions); }
            NumberOfQuestionChecker();
        }

        bool BookExistCheck(string workBookName)
        {
            return Directory.Exists(Path);
        }

        bool QuestionNumberExistCheck(int number)
        {
            return File.Exists($@"{Path}\{number}");
        }

        bool SettingExistCheck()
        {
            File.Exists($@"{Path}\data");
            return true;
        }

        public void  NumberOfQuestionChecker()
        {
            int i = 1;
            while (true)
            {
                if (Directory.Exists($@"{Path}\{i}"))
                {
                    i++;
                }
                else
                {
                    break;
                }
            }

            this.NumberOfQuestion = i - 1;
        }

        public void CreateSave(string workBookName, int numberOfQuestion)
        {
            if (!BookExistCheck(workBookName))
            {
                System.IO.Directory.CreateDirectory(Path);
                for (int i = 1; i < numberOfQuestion + 1; i++)
                {
                    System.IO.Directory.CreateDirectory($@"{Path}\{i}");
                    using (FileStream fileStream = File.Create($@"{Path}\{i}\data")) ;
                }
            }
            else
            {
                
            }
        }

        public void AddToSave(int numberOfQuestion,memoryObject memoryObject)
        {
            StreamWriter streamWriter = new StreamWriter($@"{Path}\{numberOfQuestion}\data", true);
            streamWriter.WriteLine(memoryObject.Comment + "," + memoryObject.DateTime.Ticks);
            //コメントに　,　をつけさせないようにする。
            streamWriter.Close();
        }

        public string GetAllSaveString()
        {
            string str = null;
            for (int i = 1; i <= NumberOfQuestion; i++)
            {
                str = str + GetSaveString(i);
            }

            return str;

        }

        public string GetSaveString(int numberOfQuestion)
        {
            using (StreamReader streamReader = new StreamReader($@"{Path}\{numberOfQuestion}\data", true))
            {
                return streamReader.ReadToEnd();
            }
        }

        public List<memoryObject> GetSave(int QuestionNumber)
        {
            List<memoryObject> list = new List<memoryObject>();
            using (StreamReader streamReader = new StreamReader($@"{Path}\{QuestionNumber}\data" , true))
            {
                string strr;
                if (streamReader == null)
                {
                    
                }
                else
                {
                    while (true)
                    {
                        strr = streamReader.ReadLine();
                        if (strr != null)
                        {
                            try
                            {
                                Match match = _regex.Match(strr);
                                list.Add(new memoryObject(match.Groups["Comment"].ToString(), new DateTime(Int64.Parse(match.Groups["Time"].ToString()))));
                            }
                            catch (System.FormatException e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }else{break;}
                    }
                }
            }

            return list;
        }

        public int GetLineCount(int questionNumber)
        {
            int i = 0;
            using (StreamReader streamReader = new StreamReader($@"{Path}\{questionNumber}"))
            {
                while (true)
                {
                    if (streamReader.ReadLine() != null)
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return i;
        }
    }
}