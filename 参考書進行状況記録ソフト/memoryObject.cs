﻿using System;

namespace dataTest
{
    [Serializable]
    public class memoryObject
    {
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }

        public memoryObject(string comment, DateTime dateTime)
        {
            this.Comment = comment;
            this.DateTime = dateTime;
        }
    }
}