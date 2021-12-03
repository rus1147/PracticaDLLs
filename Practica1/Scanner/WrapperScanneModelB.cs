using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerModelB;
    using ScannerBase;
using ScannerBase.Abstraccion;

namespace ScannerBase.Wrappers
{
    internal class WrapperScanneModelB : Scanner
    {
        private ScannerB _scanner;
        public WrapperScanneModelB(string destinationDirectory, ResolutionFormat resolucion)
        {
            _scanner = new ScannerB();
            _scanner.DestinationDirectory = destinationDirectory;
            _scanner.ImageRes = (ScannerB.ResolutionFormat)resolucion;
            
        }

        public override ResolutionFormat Resolucion { get; set; }
        public override void Digitalizar()
        {
            //string cm7 = 
            //ResolutionFormat resolution = this.Resolucion;
            //_scanner.ScanB();
        }
        public override void Detener()
        {
            _scanner.Close();
        }
        public override void Test()
        {
            _scanner.TestScan();
        }
        public override string DirDestino
        {
            get { return _scanner.DestinationDirectory; }
            set { _scanner.DestinationDirectory = value; }
        }
    }
}
