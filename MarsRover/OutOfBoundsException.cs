using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OutOfBoundsException : Exception
    {
        public Exception Ex { get; set; }
        public OutOfBoundsException(string message)
        {
            this.Ex = new Exception(message);
        }
    }
}
