using System;
using System.Collections.Generic;
using SQLite;

namespace BillDataStruct.Bill
{


    public class LoanBillDetails
    {
        public string transitionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public int MaxTime { get; set; }
        public int Current { get; set; }
        public float Value { get; set; }
        public float Principal { get; set; }
        public float Interest { get; set; }
    }
}
