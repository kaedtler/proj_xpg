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
        Texture2D texture;

        public int Height { get { return tiles[0].Length; } }
        public int Width { get { return tiles[0][0].Length; } }

        public Map(xpgDataLib.Map data, ContentManager Content)
        {
            tiles = data.Tiles;
            texture = Content.Load<Texture2D>("Graphics/Tilesets/" + data.TextureString);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int z = 0; z < tiles.Length; z++)
                for (int y = 0; y < tiles[z].Length; y++)
                    for (int x = 0; x < tiles[z][y].Length; x++)
                    {
                        spriteBatch.Draw(texture, new Rectangle(x * Game1.TilesWidth, y * Game1.TilesHeight, Game1.TilesWidth, Game1.TilesHeight), new Rectangle((tiles[z][y][x] - 1) % 2 * texture.Width / 2, (tiles[z][y][x] - 1) / 2 * texture.Width / 2, texture.Width / 2, texture.Width / 2), Color.White);
                    }
        }
    }
}
