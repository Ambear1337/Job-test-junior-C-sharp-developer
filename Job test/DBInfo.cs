using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Job_test
{
    class DBInfo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }

        public DBInfo() { }

        DBInfo(string C1, string C2)
        {
            Column1 = C1;
            Column2 = C2;
        }
    }
}
