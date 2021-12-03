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

            Random random = new Random();
            int quantity = random.Next(0, 9);
            Console.WriteLine("Ejecutar item 1 o item 2, ingrese 1/ 2 : ");
            string item= Console.ReadLine();
            if (item == "1")
            {
                ScannerA scannerA = new ScannerA();



                //scannerA. calidadImagen = scannerA.randomDPI();

                //            int cantidadScanns = quantity;
                //            Console.WriteLine("Cantidad de escaneos solitados es de: {0}", cantidadScanns);
                //            scannerA.MultiScan(scannerA.randomFormat(), scannerA.randomDPI(), cantidadScanns);
                //            scannerA.Stop();

                //        else
                //        {
                //            Console.WriteLine(scannerA.statusError);
                //        }
                //        Console.WriteLine("Desea borrar imagenes scanneadas ? \n y/n ?");
                //        string borrar = Console.ReadLine();
                //        if (borrar == "y")
                //        {
                //            scannerA.DeleteImagenes(scannerA.randomDPI());
                //            Console.WriteLine("Imagenes eliminadas");
                //        }
                //    }
                //    else
                //    {
                //        ScannerB scannerB = new ScannerB();

                //        scannerB.Initialize();

                //        if (quantity == 0)
                //        {
                //            Console.WriteLine(scannerB.statusError);
                //        }
                //        else if (scannerB.TestScan())
                //        {
                //            int cantidadScanns = quantity;
                //            Console.WriteLine("Cantidad de escaneos solitados es de: {0}", cantidadScanns);
                //            scannerB.MultiScan(scannerB.randomFormat(), scannerB.randomDPI(), cantidadScanns);
                //            scannerB.Close();
                //        }
                //        else
                //        {
                //            Console.WriteLine(scannerB.statusError);
                //        }

                //        //No se porque no funciona, usa el valor borrar2 el primer readline que tiene la opcion 2
                //        Console.WriteLine("Desea borrar imagenes scanneadas ? \n y/n ?");
                //        string borrar2 =  Console.ReadLine();
                //        if (borrar2 == "y")
                //        {
                //            scannerB.DeleteImagenes(scannerB.randomDPI());
                //            Console.WriteLine("Imagenes eliminadas");
                //        }

            }
        }
        }
}
