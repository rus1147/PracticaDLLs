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
            Scanner scannerA = new Scanner();
            Random random = new Random();
             
            int quantity = random.Next(0, 9);
            if(quantity == 0) {
                Console.WriteLine(scannerA.statusError);
            }
            else if (scannerA.GetStatus()== scannerA.statusOk)
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
        }
    }
}
