using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerBase;

namespace ScannerModelB
{
    public class ScannerB : Scanner
    {
        internal bool estadoScannerB;
        public ResolutionFormat _imageDpiB;
        public byte[] ScanB(string CM7C)
        {
            byte[] bytesImg;
            try
            {
                if (estadoScannerB == true)
                {
                    bytesImg = Encoding.ASCII.GetBytes(CM7C);
                    return bytesImg;
                }
            }
            catch (ScannerNotInitException)
            {
                throw new ScannerNotInitException("The student cannot be found.");
            }
            return bytesImg= Encoding.ASCII.GetBytes("ScannerNotInitException");
        }
        public byte[] ExecuteScanB(ResolutionFormat reso)
        {
            string sourceDir = @carpetaCheques + reso.ToString();
            //string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");
            Random random = new Random();
            int imageNumber = random.Next(0, 9);

            string file = picList[imageNumber];
            string fName = file.Substring(sourceDir.Length + 1);
            return ScanB(fName);
        }
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

        public ResolutionFormat ImageRes
        {

            get
            {
                return randomDPI();
            }
            set
            {
                _imageDpiB = value;
            }
        }

        
    }
}
