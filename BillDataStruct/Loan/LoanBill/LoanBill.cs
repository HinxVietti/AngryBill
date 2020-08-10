using System;
using System.Collections.Generic;
using SQLite;
namespace BillDataStruct.Bill
{

    public class LoanBill
    {
        [Unique]
        public int ProviderCode { get; set; }
        [PrimaryKey, Unique]
        public string transitionId { get; set; }
        public DateTime CreateData { get; set; }
        public TimeSpan Cycle { get; set; }
        public float Value { get; set; }
        public int stages { get; set; }
        public float DailyRatio { get; set; }
    }
}
