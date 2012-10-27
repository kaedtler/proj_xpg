using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace proj_xpg
{
    class Tileset
    {
        Texture2D texture;
        int tilesPerRow;
        byte[] collision;

        
        public Tileset(xpgDataLib.Tileset data, ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Graphics/Tilesets/" + data.File);
            tilesPerRow = data.TilesPerRow;
            collision = data.Collision;
        }


        public void Draw(SpriteBatch spriteBatch, byte[][][] tiles)
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
