using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScannerModelB
{
    public class ScannerB
    {
        public enum Resolucion { DPI_100, DPI_200, DPI_300 }
        public enum ResolutionFormat { JPG, PNG }
        public Resolucion resolucion { get; set; }
        public ResolutionFormat ImageRes { get; set; }
        internal bool estadoScannerB = false;
        public string DestinationDirectory { get; set; } = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\DestinoImg";

        public string CarpetaCheques = $"C:\\Users\\Ruslan\\Programacion\\academina BNA\\Practica1\\PracticaDLLs\\Practica1\\Img_Cheques\\";
        private int CM7Lenght = 29;
       
        public byte[] ScanB(out string CM7C)
        {
            CM7C = null;

            if (!estadoScannerB)
            {
                throw new Exception("El scanner no ha sido inicializado");
            }
            try
            {
                using (MemoryStream  ms = new MemoryStream())
                {
                    string sourceDir = CarpetaCheques + RandomDPI().ToString();
                    //string backupDir = DestinationDirectory + "\\" + RandomDPI().ToString();

                    string[] picList = Directory.GetFiles(sourceDir);

                    Random random = new Random();
                    int image = random.Next(0, 9);
                    //tomo una imagen random
                    string file = picList[image];
                    //Tomo el nombre del archivo, verifico que tenga 29 caracteres
                   
                    string fileSinDireccion = Path.GetFileNameWithoutExtension(file);
                    if (fileSinDireccion.Length== CM7Lenght+2) { 
                        //asigno al CM7C el nombre del archivo
                    CM7C = Path.GetFileNameWithoutExtension(file);
                    }
                    
                    Image newImage = Image.FromFile(file);
                    //Guardo la imagen en memoria
                    ////FALLA el guardado en memoria
                  //  newImage.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                    
                    // devuelvo un array de lo que se encuentra en memoria
                    return ms.ToArray();
                }       
            }
            catch
            {
                throw new Exception("Fallo al escanear");
            }
        }
        //public string ExecuteScanB(ImgFormtB format, ResolutionFormat reso, int quantity)
        //{
        //    string sourceDir = @carpetaCheques + reso.ToString();
        //    string backupDir = DestinationDirectory + "\\" + reso.ToString();

        //    string[] picList = Directory.GetFiles(sourceDir, "*.JPG");

        //    string file = picList[quantity];
        //    string fName = file.Substring(sourceDir.Length + 1);
        //    string fNameNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

        //    byte[] stringtoByteArrfName = ScanB(fName);
        //    byte[] stringtoByteArrfNNWEx = ScanB(fName);
        //    string convertedF = Encoding.UTF8.GetString(stringtoByteArrfName, 0, stringtoByteArrfName.Length);
        //    string convertedfNNWEx = Encoding.UTF8.GetString(stringtoByteArrfNNWEx, 0, stringtoByteArrfNNWEx.Length);

        //    if (format == ImgFormt2.JPG)
        //    {
        //        string result = Path.Combine(backupDir, convertedF);
        //        File.Copy(Path.Combine(sourceDir, convertedF), result, true);
        //        return result;
        //    }
        //    else if (format == ImgFormt2.PNG)
        //    {
        //        string result = Path.Combine(backupDir, convertedfNNWEx + ".PNG");
        //        File.Copy(Path.Combine(sourceDir, convertedF), Path.Combine(backupDir, convertedfNNWEx + ".PNG"), true);
        //        return result;
        //    }
        //    else
        //    {
        //        return statusError;
        //    }
        //}
        //public string[] MultiScan(v format, ResolutionFormat resolution, int quantity)
        //{
        //    List<string> lista = new List<string>();
        //    for (int i = 0; i < quantity; i++)
        //    {
        //        lista.Add((ExecuteScanB(format, resolution, i)));
        //    }
        //    String[] result = lista.ToArray();
        //    return result;
        //}
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

        //public ResolutionFormat ImageRes
        //{

        //    get
        //    {
        //        return randomDPI();
        //    }
        //    set
        //    {
        //        _imageDpiB = value;
        //    }
        //}

        internal Resolucion RandomDPI()
        {
            Random random = new Random();
            int imageDPI = random.Next(0, 6);
            if (imageDPI > 0 && imageDPI < 2)
            {
                return Resolucion.DPI_100;
            }
            else if (imageDPI > 2 && imageDPI < 4)
            {

                return Resolucion.DPI_200;
            }
            else
            {
                return Resolucion.DPI_300;
            }
        }
       /* public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }*/
    }
}
