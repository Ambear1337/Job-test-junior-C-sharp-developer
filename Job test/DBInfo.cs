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
        public string ServiceType { get; set; }
        public string ServiceRate { get; set; }
        public string ServiceNorm { get; set; }

        public string FullListOfServices
        {
            get
            {
                return $"{ ServiceType } { ServiceRate } { ServiceNorm } ";
            }
        }
    }
}
