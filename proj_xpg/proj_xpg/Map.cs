using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace proj_xpg
{
    public class Map
    {
        /// <summary>
        /// Z, Y, X
        /// </summary>
        byte[][][] tiles;
        Tileset tileset;
        Player player;

        public int Height { get { return tiles[0].Length; } }
        public int Width { get { return tiles[0][0].Length; } }

        public Map(xpgDataLib.Map data, ContentManager Content)
        {
            tiles = data.Tiles;
            tileset = new Tileset(Content.Load<xpgDataLib.Tileset>("Data/Tilesets/" + data.Tileset), Content);
        }
        
        public void AddPlayer(Player player)
        {
            this.player = player;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            tileset.Draw(spriteBatch, tiles);
            if (player != null) player.Draw(spriteBatch);
        }
    }
}
