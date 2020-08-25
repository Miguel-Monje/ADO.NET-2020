using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Curso.PersistenciaADO
{
    class GestionConexion
    {
        public static SqlConnection GetConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return new SqlConnection(cadena);
        }
    }
}
