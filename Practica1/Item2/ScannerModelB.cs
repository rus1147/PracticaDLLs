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
        public string ExecuteScanB(ImgFormt_JPG_or_PNG format, ResolutionFormat reso, int quantity)
        {
            string sourceDir = @carpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

            string file = picList[quantity];
            string fName = file.Substring(sourceDir.Length + 1);
            string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            byte[] stringtoByteArrfName = ScanB(fName);
            byte[] stringtoByteArrfNNWEx = ScanB(fName);
            string convertedF = Encoding.UTF8.GetString(stringtoByteArrfName, 0, stringtoByteArrfName.Length);
            string convertedfNNWEx = Encoding.UTF8.GetString(stringtoByteArrfNNWEx, 0, stringtoByteArrfNNWEx.Length);

            if (format == ImgFormt_JPG_or_PNG.JPG)
            {
                string result = Path.Combine(backupDir, convertedF);
                File.Copy(Path.Combine(sourceDir, convertedF), result, true);
                return result;
            }
            else if (format == ImgFormt_JPG_or_PNG.PNG)
            {
                string result = Path.Combine(backupDir, convertedfNNWEx + ".PNG");
                File.Copy(Path.Combine(sourceDir, convertedF), Path.Combine(backupDir, convertedfNNWEx + ".PNG"), true);
                return result;
            }
            else
            {
                return statusError;
            }
        }
        public string[] MultiScan(ImgFormt_JPG_or_PNG format, ResolutionFormat resolution, int quantity)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                lista.Add((ExecuteScanB(format, resolution, i)));
            }
            String[] result = lista.ToArray();
            return result;
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
            estadoScannerB = false;
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
