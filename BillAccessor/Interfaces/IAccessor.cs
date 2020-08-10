using System;
using System.Collections.Generic;
using BillDataStruct;
using BillDataStruct.Bill;
using BillDataStruct.User;

namespace BillAccess
{


    public interface IAccessor
    {
        DataAccessResponse Access();
        void Access(Action<DataAccessResponse> onfinished);

        User GetUser();
        UserInfo GetUserInfo();

        bool CreateLoanBill(LoanBill bill,int providerCode);

        CreditLoanProvider[] GetLoanProviders();
        void AddLoanProvider(CreditLoanProvider provider);
        LoanBill[] GetAllBills(CreditLoanProvider provider);
        LoanBill[] GetAllBillsAll();
        LoanBillDetails[] GetBillDetails(LoanBill bill);

        LoanBillDetails[] GetBillDetailsVeryCloseData(DateTime time);
        LoanBillDetails[] GetBillDetailsVeryCloseData();

    }
}
