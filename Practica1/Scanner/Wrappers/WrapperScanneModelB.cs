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

namespace ScannerBase.Wrappers
{
    internal class WrapperScanneModelB : Scanner
    {
        private ScannerB _scanner;
        public WrapperScanneModelB(string destinationDirectory, Resolution resolucion)
        {
            _scanner = new ScannerB();
            _scanner.DestinationDirectory = destinationDirectory;
            _scanner.ImageRes = (ScannerB.ResolutionFormat)resolucion;
            
        }

        public override Resolution Resolucion { get; set; }
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
