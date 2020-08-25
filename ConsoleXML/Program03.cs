using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleXML
{
    class Program03
    {
        static void Main(string[] args)
        {

            XmlReader lector = new XmlTextReader("persona.xml");
            List<Persona> lista = new List<Persona>();
            Persona p = new Persona();
            while (lector.Read())
            { 
                if (lector.NodeType == XmlNodeType.Element)
                {
                    switch (lector.Name)
                    {
                        case "persona":
                            p = new Persona();
                            break;

                        case "nombre":
                            lector.Read();
                            p.Nombre = lector.Value;
                            break;

                        case "apellidos":
                            lector.Read();
                            p.Apellidos = lector.Value;
                            break;

                        case "edad":
                            lector.Read();
                            p.Edad = Convert.ToInt32(lector.Value);
                            lista.Add(p);
                            break;

                        default:
                            break;
                    }
                }
            }

            foreach (Persona aux in lista)
            {
                Console.WriteLine(aux.Nombre + " " + aux.Apellidos);
            }
            Console.ReadLine();
         
        }
        private class Persona
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public int Edad { get; set; }
            public Persona()
            {
            }
        }

    }
}
