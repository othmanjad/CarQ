using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssigment.Models
{
    public class BaseResponse<T>
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public T Results { get; set; }

    }
}
