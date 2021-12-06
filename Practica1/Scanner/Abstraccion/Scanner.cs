using System;
using System.Collections.Generic;
using System.IO;

namespace ScannerBase.Abstraccion
{
    public abstract class Scanner
    {
        public enum Resolution { DPI_100, DPI_200, DPI_300 }
        public enum ResolutionFormat { JPG, PNG }
        public virtual Resolution Resolucion { get; set; }
        public abstract void Digitalizar();
        public abstract void Detener();
        public abstract void Test();
        public abstract string DirDestino { get; set; }


        //public readonly string statusOk = "General Status OK \n Connection: OK \n Port check: OK \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";
        //public readonly string statusError = "General Status ERROR \n Connection: OK \n Port check: FAIL \n Firmware version: 1.83 \n *Serial Nmbr: 12345.6789";

        //public static string _destinationDirectory = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\DestinoImg";
        //public ResolutionFormat _imageDpi;
        //public ImgFormt2 _imageFormat;
        //public enum ImgFormt2 { JPG, PNG }
        //public  enum ResolutionFormat { DPI_100, DPI_200, DPI_300 }

        //public static string carpetaCheques = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\Img_Cheques\\";

        //public string CopyImage(ImgFormt2 format, ResolutionFormat reso)
        //{
        //    string sourceDir = @carpetaCheques + reso.ToString();
        //    string backupDir = _destinationDirectory + "\\" + reso.ToString();

        //    string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

        //    Random random = new Random();
        //    int imageNumber = random.Next(0, 9);

        //    string file = picList[imageNumber];
        //    string fName = file.Substring(sourceDir.Length + 1);
        //    string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

        //    if (format == ImgFormt2.JPG)
        //    {
        //        string result = Path.Combine(backupDir, fName);
        //        File.Copy(Path.Combine(sourceDir, fName), result, true);
        //        return result;
        //    }
        //    else if (format == ImgFormt2.PNG)
        //    {
        //        string result = Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG");
        //        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fNameNameWithoutExtension + ".PNG"), true);
        //        return result;
        //    }
        //    else
        //    {
        //        return statusError;
        //    }
        //}

        //public ResolutionFormat randomDPI()
        //{
        //    Random random = new Random();
        //    int imageDPI = random.Next(1, 3);
        //    switch (imageDPI)
        //    {
        //        case 1:
        //            _imageDpi = ResolutionFormat.DPI_100;
        //            break;
        //        case 2:
        //            _imageDpi = ResolutionFormat.DPI_200;
        //            break;
        //        case 3:
        //            _imageDpi = ResolutionFormat.DPI_300;
        //            break;
        //    }

        //    return _imageDpi;
        //}
        //public ImgFormt2 randomFormat()
        //{
        //    Random random = new Random();
        //    int imageDPI = random.Next(1, 3);
        //    switch (imageDPI)
        //    {
        //        case 1:
        //            _imageFormat = ImgFormt2.JPG;
        //            break;
        //        case 2:
        //            _imageFormat = ImgFormt2.PNG;
        //            break;
        //    }
        //    return _imageFormat;
        //}

        //public string DestinationDirectory
        //{
        //    get
        //    {
        //        return _destinationDirectory;
        //    }

        //    set
        //    {
        //        _destinationDirectory = value;
        //    }
        //}
        //public void DeleteImagenes(ResolutionFormat reso)
        //{
        //    string backupDir = _destinationDirectory + "\\" + reso.ToString(); 
        //    DirectoryInfo dir = new DirectoryInfo(backupDir);

        //    foreach (FileInfo fi in dir.GetFiles())
        //    {
        //        fi.Delete();
        //    }
        //}

    }
}
