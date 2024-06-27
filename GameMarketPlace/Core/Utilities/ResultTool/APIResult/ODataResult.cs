using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ResultTool.APIResult
{
    public class ODataResult<TData>
    {
        public TData Data { get; set; }
    }

    public class ODataListResult<TData>
    {
        public IQueryable<object> Data { get; set; }
        public int Count { get; set; }
    }
}
