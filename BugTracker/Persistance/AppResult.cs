using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Persistance
{
    public abstract class AppRes
    {
        public string Message { get; set; }
        public bool Success { get; set; } = true;

    }
    public class AppResult<T> : AppRes where T : class
    {
        public AppResult()
        {
            if (typeof(T) != typeof(String))
                Result = (T)Activator.CreateInstance(typeof(T));

        }
        public T Result { get; set; }
    }
    public class AppResult : AppRes
    {
        public AppResult()
        {

        }
    }
}
