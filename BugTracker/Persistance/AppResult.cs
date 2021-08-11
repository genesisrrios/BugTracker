using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Persistance
{
    public class AppRes<T> where T : class
    {
        public string Message { get; set; }
        public bool Success {get;set;}
        public T Result { get; set; }

    }

}
