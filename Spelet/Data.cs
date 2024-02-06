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
        public static Random random = new Random();

        public static KeyboardState keyboard, lastKeyboard;

        public static MouseState mouse, lastMouse;

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
        {
            {"player", null },
            //{"enemy", null },
            {"tilemap", null }
        };

        public static void LoadContent(ContentManager _contentManager)
        {
            foreach (string imagename in textures.Keys)
            {
                textures[imagename] = _contentManager.Load<Texture2D>(imagename);
            }
            

            //loopa igenom dictionary för att med hjälp av contentmanager ladda in alla texturer
        }
    }
}
