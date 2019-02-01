using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_CSV_Reader_FIleTraverse
{
    public interface IQueryInterface
    {
        IQueryable<ResultObjets> ResultObjets { get; }
    }
}
