using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Reports: MyBase
    {
        public DataSet CashFlow()
        {
            return ExecuteDS("select * from vwTransaction");



        }
    }
}
