using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleXML
{
    class Program01
    {

        static  XmlDocument documento = new XmlDocument();
        static void Main(string[] args)
        {
           
            //elemento persona

           
            XmlElement personas = documento.CreateElement("personas");
            documento.AppendChild(personas);
            //atributo

            /* XmlAttribute atributo = documento.CreateAttribute("telefono");
               elemento.Attributes.Append(atributo);
               atributo.InnerText = "987654321";*/

            //distintas etiquetas de persona
            XmlElement persona = documento.CreateElement("persona");
            NuevaPersonaXml("pedro", "luis", 20, persona);
            personas.AppendChild(persona);
            persona = documento.CreateElement("persona");
            NuevaPersonaXml("juan", "fernandez", 20, persona);
            personas.AppendChild(persona);
            persona = documento.CreateElement("persona");
            NuevaPersonaXml("ana", "garcía", 20, persona);
            personas.AppendChild(persona);
            //creacion del documento
            XmlWriter escritor = new XmlTextWriter("persona.xml",null);
            documento.Save(escritor);
        }

        private static void NuevaPersonaXml(string nombre,string apellidos, int edad, XmlElement e)
        {
            XmlElement nombreEl = documento.CreateElement("nombre");
            e.AppendChild(nombreEl);
            nombreEl.InnerText = nombre;
            XmlElement apellidosEl = documento.CreateElement("apellidos");
            e.AppendChild(apellidosEl);
            apellidosEl.InnerText = apellidos;
            XmlElement edadEl = documento.CreateElement("edad");
            e.AppendChild(edadEl);
            edadEl.InnerText = edad.ToString();
        }
    }
}
