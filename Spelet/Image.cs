using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Spelet
{
    internal class Image : UIElement
    {
        //en bild som kommer ritas ut, d.v.s. också har position och storlek
        public Image(Vector2 position, Vector2 size, Texture2D image) : base(position, size)
        {
            background = image;
        }
    }
}
