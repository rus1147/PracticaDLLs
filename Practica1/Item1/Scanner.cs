using System;
using System.Collections.Generic;
using System.IO;


namespace Item1
{
    public class Scanner1
    {
        public readonly string statusOk = "General Status OK \n Connection: OK \n Port check: OK \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";
        public readonly string statusError = "General Status ERROR \n Connection: OK \n Port check: FAIL \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";

        internal string _destinationDirectory;
        private ResolutionFormat _imageDpi;
        private ImgFormt_JPG_or_PNG _imageFormat;
        public enum ImgFormt_JPG_or_PNG { JPG, PNG }
        public enum ResolutionFormat { DPI_100, DPI_200, DPI_300 }



        internal static string carpetaCheques = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\Img_Cheques\\";
        //public void Copytodos()

        //{
        //    string sourceDir = @carpetaCheques;
        //    string backupDir = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\DestinoImg";

        //    try
        //    {
        //        try
        //        {
        //            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");
        //            // Copy picture files.
        //            foreach (string f in picList)
        //            {
        //                // Remove path from the file name.
        //                string fName = f.Substring(sourceDir.Length + 1);

        //                // Use the Path.Combine method to safely append the file name to the path.
        //                // Will overwrite if the destination file already exists.
        //                //copia todos los archivos // cambiar para que copie uno solo
        //                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);

        //            }
        //        }
        //        catch (IOException copyError)
        //        {
        //            Console.WriteLine(copyError.Message);
        //        }
        //    }

        //    catch (DirectoryNotFoundException dirNotFound)
        //    {
        //        Console.WriteLine(dirNotFound.Message);
        //    }
        //}

        //public void CopyFie()
        //{
        //    string sourceDir = @carpetaCheques;
        //    string backupDir = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\DestinoImg";
        //    try
        //    {
        //        try
        //        {
        //            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

        //            // Copy picture files.
        //            foreach (string f in picList)
        //            {
        //                // Remove path from the file name.
        //                string fName = f.Substring(sourceDir.Length + 1);

        //                // Use the Path.Combine method to safely append the file name to the path.
        //                // Will overwrite if the destination file already exists.
        //                //copia todos los archivos // cambiar para que copie uno solo
        //                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);

        //            }
        //        }
        //        catch (IOException copyError)
        //        {
        //            Console.WriteLine(copyError.Message);
        //        }
        //    }

        //    catch (DirectoryNotFoundException dirNotFound)
        //    {
        //        Console.WriteLine(dirNotFound.Message);
        //    }
        //}
        public string Scan(ImgFormt_JPG_or_PNG format, ResolutionFormat reso)
        {
            return CopyImage(format, reso);

        }
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
        public string CopyImage(ImgFormt_JPG_or_PNG format, ResolutionFormat reso)
        {
            string sourceDir = @carpetaCheques + reso.ToString();
            string backupDir = DestinationDirectory + "\\" + reso.ToString();

            string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

            Random random = new Random();
            int imageNumber = random.Next(0, 9);

            string file = picList[imageNumber];
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
        public string[] MultiScan(ImgFormt_JPG_or_PNG format, ResolutionFormat resolution, int quantity) { 
            List<string> lista = new List<string>();
            for(int i = 0; i < quantity; i++)
            {
                lista.Add((CopyImage(format, resolution,i)));
            }
            String[] result = lista.ToArray();
            return result;
        }
        public ResolutionFormat randomDPI()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 3);
            switch (imageDPI)
            {
                case 1:
                    _imageDpi = ResolutionFormat.DPI_100;
                    break;
                case 2:
                    _imageDpi = ResolutionFormat.DPI_200;
                    break;
                case 3:
                    _imageDpi = ResolutionFormat.DPI_300;
                    break;
            }

            return _imageDpi;
        }
        public ImgFormt_JPG_or_PNG randomFormat()
        {
            Random random = new Random();
            int imageDPI = random.Next(1, 3);
            switch (imageDPI)
            {
                case 1:
                    _imageFormat = ImgFormt_JPG_or_PNG.JPG;
                    break;
                case 2:
                    _imageFormat = ImgFormt_JPG_or_PNG.PNG;
                    break;
            }
            return _imageFormat;
        }

        internal string DestinationDirectory
        {
            get
            {
                return _destinationDirectory = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\DestinoImg";
            }

            set
            {
                _destinationDirectory = value;
            }
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
