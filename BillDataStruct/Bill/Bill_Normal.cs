using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace BillDataStruct.Bill
{
    public class Bill_Normal
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int index { get; set; }
        public string Serial_Number { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public float Fee { get; set; }
        public FeeType FeeType { get; set; }
        public virtual int FeeTags { get; set; }
        public virtual int FeeAccount { get; set; }
    }
}
