using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Documents;
using dataTest;

namespace 参考書進行状況記録ソフト
{
    [Serializable()]
    public class LastSave
    {
        /// <summary>
        /// int 問題番号
        /// </summary>
        public Dictionary<int, memoryObject> List = new Dictionary<int, memoryObject>();
        
    }
}