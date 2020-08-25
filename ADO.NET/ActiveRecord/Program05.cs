using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
{
    class Program05
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FacturaActiveRecord.UnidadesTotales());
            Console.ReadLine();
        }
    }
}
