using System;
using System.Collections.Generic;
using System.IO;
using ScannerBase;
namespace ScannerModelA
{
    public class ScannerA : Scanner
    {
        public string CopyImage(ImgFormt_JPG_or_PNG format, ResolutionFormat reso, int quantity)
        {
            string sourceDir = @carpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

            string file = picList[quantity];
            string fName = file.Substring(sourceDir.Length + 1);
            string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            if (format == ImgFormt_JPG_or_PNG.JPG)
            {
                string result = Path.Combine(backupDir, fName);
                File.Copy(Path.Combine(sourceDir, fName), result, true);
                return result;
            }
            else if (format == ImgFormt_JPG_or_PNG.PNG)
            {
                string result = Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG");
                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG"), true);
                return result;
            }
            else
            {
                return statusError;
            }
        }

        public string DestinationDirectory
        {
            get
            {
                return _destinationDirectory;
            }

            set
            {
                _destinationDirectory = value;
            }
        }

        public string[] MultiScan(ImgFormt_JPG_or_PNG format, ResolutionFormat resolution, int quantity)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                lista.Add((CopyImage(format, resolution, i)));
            }
            String[] result = lista.ToArray();
            return result;
        }

        public void Stop()
        {
            Console.WriteLine("Scanner has been interrupted");
        }

        public string GetStatus()
        {
            Random random = new Random();
            int statusNumber = random.Next(0, 5);

            if (statusNumber < 5)
            {
                return statusOk;
            }
            else
            {
                return statusError;
            }
        }

    }
}       