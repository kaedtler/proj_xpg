using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proj_xpg
{
    public class XpgMap
    {
        public int Width;
        public int Height;

        public XpgMap()
        {
            Width = 0;
            Height = 0;
        }

        public XpgMap(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
