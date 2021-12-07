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
            Console.WriteLine("Ejecutar ScannerA (1) o ScannerB (2), ingrese 1/ 2 : ");
            string item = Console.ReadLine();
            if (item == "1")
            {
                ScannerA scannerA = new ScannerA();

             
                int cantidadScanns = quantity;

                Console.WriteLine("Cantidad de escaneos solitados es de: {0}", cantidadScanns);
                try
                {
                    scannerA.MultiScan(scannerA.randomFormat(), scannerA.RandomDPI(), cantidadScanns);
                    scannerA.Stop();
                }
                catch
                {
                    throw new Exception("No se pudo digitalizar: Scanner A");
                }
            }
            else
            {
                ScannerB scannerB = new ScannerB();

                scannerB.Initialize();
                string imagen;

                if (scannerB.TestScan())
                {
                    scannerB.ScanB(out imagen);
                    Console.WriteLine(imagen);
                    scannerB.Close();
                }
                else
                {
                    throw new Exception("No se puedo digitalizar");
                }
            }
        }
    }
}