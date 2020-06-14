using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillDataStruct.User
{
    public class User
    {
        [SQLite.Unique, SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int uid { get; set; }
        public string displayName { get; set; }
        [SQLite.Unique]
        public string uName { get; set; }

        public string udb_uri { get; set; }
        public string udb_web { get; set; }
        public string udb_bak { get; set; }
    }
}
