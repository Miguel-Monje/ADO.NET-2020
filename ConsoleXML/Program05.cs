using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleXML
{
    class Program05
    {
        static void Main(string[] args)
        {

            StringBuilder cadena = new StringBuilder();

            for ( int i = 0; i<20000; i++)
            {
                cadena.Append("hola");
                cadena.Append(i);
                cadena.Append("adios");
                cadena.Append("hola2"); 

            }

            Console.WriteLine("termino");
            Console.ReadLine();
        }

    }
}
