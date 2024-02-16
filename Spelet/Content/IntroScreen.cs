using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Spelet.Content
{
    internal class IntroScreen
    {
        Animation introAnimation;
        

        public IntroScreen(GameTime gameTime, Entity entity)
        {
            entity.texture = Data.textures["beginning_screen"];
            introAnimation = new Animation(0, 4, 0.4f, 96);
            entity.sourceRectangle = introAnimation.GetFrame();

        }

        public void Update(GameTime gameTime)
        {
            introAnimation.Update(gameTime);
        }
        




    }
}
