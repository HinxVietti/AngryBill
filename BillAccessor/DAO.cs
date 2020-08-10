using System;
using System.Collections.Generic;
using BillDataStruct.User;
using SQLite;
using BillDataStruct.Bill;

internal class DAO
{
    private User user;
    private SQLiteConnection conn;

    public DAO(User user)
    {
        this.user = user;
    }

    internal void Initialize(string uri)
    {
        var connString = new SQLiteConnectionString(uri, true,
    key: "angrybill123."
    //, preKeyAction: db => db.Execute("PRAGMA cipher_default_use_hmac = OFF;"),
    //postKeyAction: db => db.Execute("PRAGMA kdf_iter = 128000;")
    );
        this.conn = new SQLiteConnection(connString);

        conn.CreateTable<User>();
        conn.CreateTable<UserInfo>();
        conn.CreateTable<CreditLoanProvider>();
        conn.CreateTable<LoanBill>();
        //conn.CreateTable<UserInfo>();
        //conn.CreateTable<UserInfo>();
        //conn.CreateTable<UserInfo>();

    }

    internal void Add<T>(T obj)
    {
        conn.Insert(obj);
    }

    internal CreditLoanProvider GetProvider(int providerCode)
    {
        try
        {
            return conn.Query<CreditLoanProvider>(string.Format("select * from \"{0}\" where ProviderCode={1}", typeof(CreditLoanProvider).Name, providerCode))?[0];
            //return conn.Get<CreditLoanProvider>("");
        }
        catch
        {
            return null;
        }
    }

    internal LoanBill[] GetBills(int providerCode)
    {
        var lst = conn.Query<LoanBill>("select * from LoanBill");
        lst.RemoveAll(i => i.ProviderCode != providerCode);
        return lst.ToArray();
    }

    internal T[] Get<T>() where T : new()
    {
        return conn.Query<T>(string.Format("select * from \"{0}\"", typeof(T).Name)).ToArray();
    }

    internal UserInfo GetUserInfo(User user)
    {
        var infos = new List<UserInfo>(Get<UserInfo>());
        return infos.Find(i => string.Equals(user.uName, i.uName));
    }
}
