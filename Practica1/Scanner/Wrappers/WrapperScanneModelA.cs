using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerModelA;
using ScannerBase;
using ScannerBase.Abstraccion;

namespace ScannerBase.Wrappers
{
    public class WrapperScanneModelA : Scanner
    {

        private ScannerA _scanner;
        public WrapperScanneModelA(string destinationDirectory, ResolutionFormat resolucion)
        {
            _scanner = new ScannerA();
            _scanner.DestinationDirectory = destinationDirectory;
            _scanner.ImageRes = (ScannerA.ResolutionFormat)resolucion; 
        }   

        public override ResolutionFormat Resolucion { get; set; }       
        public override void Digitalizar()
        {
            ResolutionFormat resolution = this.Resolucion;
            _scanner.ScanA((ScannerA.ImgFormtA)ImgFormt.PNG, (ScannerA.ResolutionFormat)resolution);
        }
        public override void Detener()
        {
            _scanner.Stop();   
        }
        public override void Test()
        {
            _scanner.Test();
        }
        public override string DirDestino {
            get { return _scanner.DestinationDirectory;}
            set { _scanner.DestinationDirectory = value; }
        }

    }
}
