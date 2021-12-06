using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerBase;
using ScannerModelA;
using ScannerModelB;
using static ScannerBase.Abstraccion.Scanner;

namespace ScannerBase.Transformador
{
    
    public class TransformadorFormatos<T> where T:struct
    {
         
        public static T ConvertToEnum(string value)
        {
            T resolucion;       
            if(!Enum.TryParse(value,out resolucion))
            {
                throw new Exception("No se puede utilizar esta resolucion");
            }
            return resolucion;
        }

        public static Resolution ConvertToResolucion(T value)
        {
            Resolution resolucion;
            if(Enum.TryParse(value.ToString(),out resolucion))
            {
                throw new Exception("No se puede utilizar esta resolucion");
            }
            return resolucion;
        }
    }
}
