using SQLite;
using System;
using System.Collections.Generic;


namespace BillDataStruct.Bill
{

    public class CreditLoanProvider
    {
        [PrimaryKey]
        public string BankName { get; set; }
        [Unique]
        public int ProviderCode { get; set; }
        public float UpperLimit { get; set; }
        public float AlreadyUsed { get; set; }
    }

}
