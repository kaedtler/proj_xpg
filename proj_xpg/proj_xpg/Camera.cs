using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

// TODO Auflösungswerte beziehen
namespace proj_xpg
{
    public class Camera
    {
        public Vector2 Position { get; private set; }
        Vector2 maxPosition = new Vector2(0, 0);
        public Matrix Matrix
        {
            get { return Matrix.CreateTranslation(-(Position.X), -(Position.Y), 0); }
        }
        public Rectangle ViewPort
        {
            get { return new Rectangle(Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y), 1280, 720); }
        }

        public Camera()
        {
        }


        public Camera(Vector2 maxPosition)
        {
            this.maxPosition = maxPosition - new Vector2(1280, 720);
        }


        public Camera(int width, int height)
        {
            this.maxPosition = new Vector2(width - 1280, height - 720);
        }


        public void SetPosition(Vector2 position, bool center)
        {
            if (center)
                position = new Vector2(position.X - 640, position.Y - 360);
            //this.position = position;
            Position = new Vector2(Math.Min(Math.Max(Convert.ToInt32(position.X), 0), maxPosition.X), Math.Min(Math.Max(Convert.ToInt32(position.Y), 0), maxPosition.Y));
        }


    }
}
