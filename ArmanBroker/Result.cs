using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmanBroker
{
    public class Result
    {
        public int StatusCode { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string InnerResult { get; set; }
    }
}
