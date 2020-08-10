using System;
using System.Collections.Generic;
using BillAccess;
using BillDataStruct.Bill;
using BillDataStruct.User;

public static class Accessor
{
    public static IAccessor GetAccessor()
    {
        var usr = GetDefaultUser();
        DAO dao = new DAO(usr);
        dao.Initialize(usr.udb_uri);
        return new standaloneDataAccessor(dao);
    }

    public static CreateUserResponse CreateUser(UserCreateInfo info)
    {
        return UserManager.CreateUser(info);
    }



    private class standaloneDataAccessor : IAccessor
    {
        private DAO dao;

        public standaloneDataAccessor(DAO dao)
        {
            this.dao = dao;
        }


        public DataAccessResponse Access()
        {
            return new DataAccessResponse()
            {
                code = 0,
                message = "pass as root",
                result = true
            };
        }

        public void Access(Action<DataAccessResponse> onfinished)
        {
            onfinished?.Invoke(new DataAccessResponse()
            {
                code = 0,
                message = "pass as root",
                result = true
            });
        }

        public void AddLoanProvider(CreditLoanProvider provider)
        {
            dao.Add(provider);
        }

        public bool CreateLoanBill(LoanBill bill, int providerCode)
        {
            CreditLoanProvider provider = dao.GetProvider(providerCode);
            if (provider == null)
                return false;
            bill.ProviderCode = provider.ProviderCode;
            dao.Add(bill);
            return true;
        }

        public LoanBill[] GetAllBills(CreditLoanProvider provider)
        {
            return dao.GetBills(provider.ProviderCode);
        }

        public LoanBill[] GetAllBillsAll()
        {
            List<LoanBill> bills = new List<LoanBill>();
            var ps = GetLoanProviders();
            for (int i = 0; i < ps.Length; i++)
                bills.AddRange(GetAllBills(ps[i]));

            return bills.ToArray();
        }

        public LoanBillDetails[] GetBillDetails(LoanBill bill)
        {
            var res = new LoanBillDetails[bill.stages];
            for (int i = 0; i < res.Length; i++)
                res[i] = CreateBillDetail(i, bill);
            return res;
        }

        private LoanBillDetails CreateBillDetail(int i, LoanBill bill)
        {
            var t = bill.CreateData;
            for (int j = 0; j < bill.stages; j++)
                t += bill.Cycle;
            //var ts = bill.Cycle * bill.stages;
            var res = new LoanBillDetails
            {
                Current = i + 1,
                StartTime = bill.CreateData,
                Deadline = t,
                Interest = (bill.stages - i) * bill.Value / bill.stages * bill.DailyRatio * 30,
                Principal = bill.Value / bill.stages,
                MaxTime = bill.stages,
                transitionId = bill.transitionId,
            };
            res.Value = res.Interest + res.Principal;
            return res;
        }

        public LoanBillDetails[] GetBillDetailsVeryCloseData(DateTime time)
        {
            return null;
        }

        public LoanBillDetails[] GetBillDetailsVeryCloseData()
        {
            return GetBillDetailsVeryCloseData(DateTime.Now);
        }

        public CreditLoanProvider[] GetLoanProviders()
        {
            return dao.Get<CreditLoanProvider>();
        }

        public User GetUser()
        {
            return GetDefaultUser();
        }

        public UserInfo GetUserInfo()
        {
            return dao.GetUserInfo(GetUser());
        }
    }


    private static User User;
    private static User GetDefaultUser()
    {
        if (User == null)
            User = new User()
            {
                displayName = "Angry手账默认用户",
                udb_bak = "Data/data.db.bak",
                udb_uri = "Data/data.db",
                udb_web = "Data/data_web.db",
                uName = "angry_root",
            };
        return User;
    }

}
