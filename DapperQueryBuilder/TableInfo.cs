using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperQueryBuilder
{
    public class TableInfo
    {
        public string TableName { get; set; }
        public string Schema { get; set; }
        public List<string> Columns { get; set; }
    }
}
