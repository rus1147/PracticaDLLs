using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerModelB;
using ScannerBase;
using ScannerBase.Abstraccion;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using ScannerBase.Transformador;

namespace ScannerBase.Wrappers
{
    internal class WrapperScanneModelB : Scanner
    {
        private ScannerB _scanner;
        public WrapperScanneModelB(string destinationDirectory, Resolution resolucion)
        {
            _scanner = new ScannerB();
            _scanner.DestinationDirectory = destinationDirectory;
            this.Resolucion = resolucion;
            
        }

        public override Resolution Resolucion { 
            get => TransformadorFormatos<ScannerB.Resolucion>.ConvertToResolucion(_scanner.resolucion);
            set => _scanner.resolucion= TransformadorFormatos<ScannerB.Resolucion>.ConvertToEnum(value.ToString()); }
        public override void Digitalizar()
        {
            string CM7;
            byte[] data = _scanner.ScanB(out CM7);
            Image newImage = Image.FromStream(new MemoryStream(data));
            newImage.Save(DirDestino,ImageFormat.Png);
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
