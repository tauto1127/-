using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Xps;
using dataTest;

namespace 参考書進行状況記録ソフト
{
    class SaveManager
    {
        public int NumberOfQuestion { get; set; }
        public string Path { get; set; }
        private readonly Regex _regex = new Regex(@"(?<Comment>.+),(?<Time>..................)");
        public static LastSave LastSave = new LastSave();

        private readonly string RecentryFileName = "RecentryData";
        public SaveManager(string bookName)
        {
            Path = Info.homePath + bookName;
            NumberOfQuestionChecker();
            try
            {
                LastSave = (LastSave) LoadRecentryHistory();
            }
            catch (SerializationException e)
            {

                MessageBox.Show(e.ToString());
                throw;
            }
            catch (FileNotFoundException e)
            {
                SaveRecentryHistory();
            }
        }
        
        public SaveManager(string bookName, int NumberOfQuestions) : this(bookName)
        {
            if (!BookExistCheck(bookName)) { CreateSave(bookName, NumberOfQuestions); }

            try
            {
                LastSave.List.Add(1,new memoryObject("abcdefg",new DateTime(637541280000000000)));
                LastSave.List.Add(1, new memoryObject("あいうえおは", new DateTime(637551280000000000)));
            }
            catch (ArgumentException e)
            {
                throw;
            }
        }

        public SaveManager(Book book)
        {
            Path = book.Path;
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

        void SaveRecentryHistory()
        {
            if (System.IO.File.Exists($@"{Path}\{RecentryFileName}"))
            {
                using (FileStream fs = new FileStream($@"{Path}\{RecentryFileName}", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    try
                    {
                        binaryFormatter.Serialize(fs, LastSave);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        throw;
                    }
                }
            }
            else
            {

            }
        }

        Object LoadRecentryHistory()
        {
            first:
            //ファイルがなかったら作成します。
            if (System.IO.File.Exists($@"{Path}\{RecentryFileName}"))
            {
                using (FileStream fileStream = new FileStream($@"{Path}\{RecentryFileName}",FileMode.Open,FileAccess.Read))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    try
                    {
                        return binaryFormatter.Deserialize(fileStream);
                    }
                    catch (SerializationException e)
                    {
                        throw;
                        MessageBox.Show(e.Message);
                        return null;
                    }
                }
            }
            else
            {
                File.Create($@"{Path}\{RecentryFileName}");
                goto first;
            }
            
        }

        public LastSave GetLastSave()
        {
            return LastSave;
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
                    FileStream fileStream = File.Create($@"{Path}\{i}\data");
                    fileStream.Close();
                }

                using (FileStream fileStream = File.Create($@"{Path}\data"))
                {
                    
                }
                /*try
                {
                    using (StreamWriter streamWriter = new StreamWriter($@"{Path}\data",true))
                    {
                        for (int i = 1; i < numberOfQuestion; i++)
                        {
                            streamWriter.WriteLine("");
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }*/
                
                
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

        public List<memoryObject> GetSave(int questionNumber)
        {
            List<memoryObject> list = new List<memoryObject>();
            using (StreamReader streamReader = new StreamReader($@"{Path}\{questionNumber}\data" , true))
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

    class RecentrySaveList : List<memoryObject>
    {
        
    }
    
}