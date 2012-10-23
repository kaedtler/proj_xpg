using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace test_xml_export
{
    class Program
    {
        static void Main(string[] args)
        {
            proj_xpg.XpgMap map = new proj_xpg.XpgMap(20,11);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("map001.xml", settings))
            {
                IntermediateSerializer.Serialize(writer, map, null);
            }

        }
    }
}
