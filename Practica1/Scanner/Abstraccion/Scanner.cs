using System;
using System.Collections.Generic;
using System.IO;

namespace ScannerBase.Abstraccion
{
    public abstract class Scanner
    {
        public enum Resolution { DPI_100, DPI_200, DPI_300 }
        public virtual Resolution Resolucion { get; set; }
        public abstract void Digitalizar();
        public abstract void Detener();
        public abstract void Test();
        public abstract string DirDestino { get; set; }

    }
}
