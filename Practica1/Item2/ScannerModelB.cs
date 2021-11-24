using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerBase;

namespace ScannerModelB
{
    public class ScannerB: Scanner
    {
        internal bool estadoScannerB;
        public ResolutionFormat _imageDpiB;

        public void Initialize()
        {
            estadoScannerB = true;
        }

        public bool TestScan()
        {
            return estadoScannerB;
        }

        public void Close()
        {
            estadoScannerB &= false;
        }

        public ResolutionFormat  ImageRes{

            get{
                return randomDPI();
            }   
            set{
                _imageDpiB = value;
            }
        }
}
}
