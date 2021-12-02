using System;
using System.Collections.Generic;
using System.IO;
using ScannerBase;
namespace ScannerModelA
{
    public class ScannerA
    {
        public enum ResolutionFormat { DPI_200, DPI_300 }
        public enum ImgFormtA { JPG, PNG }
        public string DestinationDirectory { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        string CarpetaCheques = AppDomain.CurrentDomain.BaseDirectory + "\\Img_Cheques\\";


        public string ScanA(ImgFormtA format, ResolutionFormat reso, int quantity)
        {

            string sourceDir = CarpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

            string file = picList[quantity];
            string fName = file.Substring(sourceDir.Length + 1);
            string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            if (format == ImgFormtA.JPG)
            {
                string result = Path.Combine(backupDir, fName);
                File.Copy(Path.Combine(sourceDir, fName), result, true);
                return result;
            }
            else if (format == ImgFormtA.PNG)
            {
                string result = Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG");
                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG"), true);
                return result;
            }
            return null;
        }

        public string[] MultiScan(ImgFormtA format, ResolutionFormat resolution, int quantity)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                lista.Add((ScanA(format, resolution, i)));
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
                return "General Status OK \n Connection: OK \n Port check: OK \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";
            }
            else
            {
                return "General Status ERROR \n Connection: OK \n Port check: FAIL \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";
            }
        }
        internal ResolutionFormat RandomDPI()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 3);
            if (imageDPI < 2)
            {

                return ResolutionFormat.DPI_200;
            }
            else
            {
                return ResolutionFormat.DPI_300;
            }
        }


        public ImgFormtA randomFormat()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 4);
            if (imageDPI < 2)
            {
                return ImgFormtA.JPG;
            }

            else
            {
                return ImgFormtA.PNG;

            }

        }

    }
}