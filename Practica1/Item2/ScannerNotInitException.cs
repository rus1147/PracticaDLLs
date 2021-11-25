using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerModelB
{
    internal class ScannerNotInitException: Exception 
    {
        public ScannerNotInitException() { }
        public  ScannerNotInitException(string message)
        : base(message) {
        }
    }
}
