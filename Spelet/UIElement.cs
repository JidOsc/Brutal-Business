using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class UIelement : Hitbox
    {
        public Texture2D background;
        
        public UIelement()
        {
            background = Data.textures["Button"];
        }
    }
}
