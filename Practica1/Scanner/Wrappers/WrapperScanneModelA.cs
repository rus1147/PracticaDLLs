using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerModelA;
using ScannerBase;
using ScannerBase.Abstraccion;
using ScannerBase.Transformador;
namespace ScannerBase.Wrappers
{
    public class WrapperScanneModelA : Scanner
    {

        private ScannerA _scanner;
        public WrapperScanneModelA(string destinationDirectory, Resolution resolucion)
        {
            _scanner = new ScannerA();
            _scanner.DestinationDirectory = destinationDirectory;
            _scanner.resolucion = (ScannerA.Resolucion)resolucion; 
        }   

        public override Resolution Resolucion { get; set; }       
        public override void Digitalizar()
        {
            Resolution resolution = TransformadorFormatos<Resolution>.ConvertToEnum(this.Resolucion.ToString());
            _scanner.ScanA((ScannerA.ResolutionFormat)ResolutionFormat.PNG, (ScannerA.Resolucion)resolution);
        }
        public void MultiDigitalizar(int quantity)
        {
            Resolution resolution = TransformadorFormatos<Resolution>.ConvertToEnum(this.Resolucion.ToString());
            _scanner.MultiScan((ScannerA.ResolutionFormat)ResolutionFormat.PNG, (ScannerA.Resolucion)resolution, quantity);
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
