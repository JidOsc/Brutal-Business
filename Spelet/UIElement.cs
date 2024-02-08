using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class UIElement : Hitbox
    {
        public Texture2D background;
        
        public UIElement()
        {
            background = Data.textures["background"];
        }
    }
}
