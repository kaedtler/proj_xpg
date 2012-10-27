using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using xpgDataLib;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace temp_mapCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            byte[][][] l1 = new byte[][][] {new byte[][]{
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                new byte[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,}}};

            map.Tiles = l1;
            map.Tileset = "tileset01";

            Tileset tileset01 = new Tileset();
            tileset01.File = "tileset01";
            tileset01.TilesPerRow = 2;
            tileset01.Collision = new byte[] { 0, 0, 0, 0 }; 



            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("map.xml", settings))
                IntermediateSerializer.Serialize(writer, map, null);
            using (XmlWriter writer = XmlWriter.Create("tileset01.xml", settings))
                IntermediateSerializer.Serialize(writer, tileset01, null);
        }
    }
}
