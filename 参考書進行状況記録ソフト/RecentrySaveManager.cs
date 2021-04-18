using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 参考書進行状況記録ソフト
{
    public class RecentrySaveManager
    {
        private object _recentrySave;

        //最近の勉強記録関係
        void SaveRecentryHistory()
        {
            using (FileStream fs = new FileStream($@"{Path}\History", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, _recentrySave);
            }
            
            
        }

        void LoadRecentryHistory()
        {
            //ファイルがなかったら作成します。
            
        }
    }
}