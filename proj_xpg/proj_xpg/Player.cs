using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace proj_xpg
{
    public class Player
    {
        Vector2 position;
        Texture2D texture;
        Direction direction;
        float tilesPerSecond;

        public Player(Texture2D texture, Vector2 position, Direction direction, float tilesPerSecond)
        {
            this.texture = texture;
            this.position = position;
            this.direction = direction;
            this.tilesPerSecond = tilesPerSecond;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,
                new Rectangle((int)(position.X * Game1.TilesWidth - texture.Width / 6),
                (int)((position.Y - 1) * Game1.TilesHeight),
                Game1.TilesWidth / (int)(texture.Width / 1.5) * texture.Width,
                Game1.TilesHeight / (texture.Height / 8) * texture.Height / 4),
                new Rectangle(0, texture.Height / 4 * (int)direction, texture.Width, texture.Height / 4),
                Color.White);
        }
    }
}
