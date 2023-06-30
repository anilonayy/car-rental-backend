using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Functions
{
    public static class DateFunctions
    {
        public static TimeSpan DateDifferent(DateTime startDate,DateTime endDate)
        {
            return endDate - startDate;
        }
        public static TimeSpan DateDifferentByString(string startDate,string endDate)
        {
            DateTime sd  = DateTime.Parse(startDate);
            DateTime ed = DateTime.Parse(endDate);

            return ed.Date - sd.Date;
        }
    }
}
