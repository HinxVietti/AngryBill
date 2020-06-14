using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace BillDataStruct.User
{
    public class UserInfo
    {
        [Unique, PrimaryKey]
        public string uName { get; set; }
        public string uHead { get; set; }
        public string uSlug { get; set; }

    }
}
