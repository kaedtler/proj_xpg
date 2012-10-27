using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace xpgDataLib
{
    public class Map
    {
        /// <summary>
        /// Z, Y, X
        /// </summary>
        public byte[][][] Tiles;
        public String Tileset;
    }
}
