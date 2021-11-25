using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerBase;
using ScannerModelB;
using ScannerModelA;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejecutar item 1 o item 2, ingrese 1/ 2 : ");
            int item= Console.Read();
            if (item == 1)
            {
                ScannerA scannerA = new ScannerA();
                Random random = new Random();
                //scannerA. calidadImagen = scannerA.randomDPI();
                int quantity = random.Next(0, 9);
                if (quantity == 0)
                {
                    Console.WriteLine(scannerA.statusError);
                }
                else if (scannerA.GetStatus() == scannerA.statusOk)
                {
                    int cantidadScanns = quantity;
                    Console.WriteLine("Cantidad de escaneos solitados es de: {0}", cantidadScanns);
                    scannerA.MultiScan(scannerA.randomFormat(), scannerA.randomDPI(), cantidadScanns);
                    scannerA.Stop();
                }
                else
                {
                    Console.WriteLine(scannerA.statusError);
                }
                Console.WriteLine("Desea borrar imagenes scanneadas ? \n y/n ?");
                string borrar = Console.ReadLine();
                if (borrar == "y")
                {
                    scannerA.DeleteImagenes(scannerA.randomDPI());
                    Console.WriteLine("Imagenes eliminadas");
                }
            }
            else
            {
                //scannerB
                ScannerB scannerB = new ScannerB();
                scannerB.Initialize();
                //string sourceDir = @carpetaCheques + scannerModelB.ImageRes.ToString();
                //string[] picList = sc.GetFiles(sourceDir, "*.JPG");

                //string file = picList[quantity];
              
                Console.WriteLine(scannerB.ExecuteScanB(scannerB.randomDPI()).ToString());
            }
        }
    }
}
