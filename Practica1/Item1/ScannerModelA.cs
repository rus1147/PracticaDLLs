using System;
using System.Collections.Generic;
using System.IO;
namespace ScannerModelA
{
    public class ScannerA
    {
        public enum Resolucion { DPI_200, DPI_300 }
        public enum ResolutionFormat { JPG, PNG }
        public  Resolucion resolucion { get; set; } 

        public string DestinationDirectory { get; set; } = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\DestinoImg";

        public string CarpetaCheques = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\Img_Cheques\\";

        public string ScanA(ResolutionFormat format, Resolucion reso)
        {

            string sourceDir = CarpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");
            Random r = new Random();
            int index= r.Next(0,10);
            string file = picList[index];
            string fName = file.Substring(sourceDir.Length + 1);
            string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            if (format == ResolutionFormat.JPG)
            {
                string source = Path.Combine(sourceDir, fName);
                string result = Path.Combine(backupDir, fName);
                File.Copy(source, result, true);
                return result;
            }
            else if (format == ResolutionFormat.PNG)
            {
                string source = Path.Combine(sourceDir, fName);
                string result = Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG");
                File.Copy(source, result, true);
                return result;
            }
            return null;
        }
        public string ScanA(ResolutionFormat format, Resolucion reso, int quantity)
        {

            string sourceDir = CarpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

            string file = picList[quantity];
            string fName = file.Substring(sourceDir.Length + 1);
            string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

            if (format == ResolutionFormat.JPG)
            {
                string source = Path.Combine(sourceDir, fName);
                string result = Path.Combine(backupDir, fName);
                File.Copy(source, result, true);
                return result;
            }
            else if (format == ResolutionFormat.PNG)
            {
                string source = Path.Combine(sourceDir, fName);
                string result = Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG");
                File.Copy(source, result, true);
                return result;
            }
            return null;
        }

        public string[] MultiScan(ResolutionFormat format, Resolucion resolution, int quantity)
        {
            string[] lista = new string[quantity];

            //List<string> lista = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                lista[i] = ScanA(format, resolution, i);
                //    lista.Add((ScanA(format, resolution, i)));
            }
            //String[] result = lista.ToArray();
            return lista;
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
        public Resolucion RandomDPI()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 3);
            if (imageDPI < 2)
            {

                return Resolucion.DPI_200;
            }
            else
            {
                return Resolucion.DPI_300;
            }
        }
        public bool Test()
        {
            return true;
        }

        public ResolutionFormat randomFormat()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 4);
            if (imageDPI < 2)
            {
                return ResolutionFormat.JPG;
            }

            else
            {
                return ResolutionFormat.PNG;

            }

        }

    }
}