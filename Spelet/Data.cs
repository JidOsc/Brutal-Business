using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class Data
    {
        public static KeyboardState keyboard, lastKeyboard;

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
        {
            {"player", null },
            {"enemy", null },
            {"tilemap", null }
        };

        public static void LoadContent(ContentManager _contentManager)
        {
            
            

            //loopa igenom dictionary för att med hjälp av contentmanager ladda in alla texturer
        }
    }
}
