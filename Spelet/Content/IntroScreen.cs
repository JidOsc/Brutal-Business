using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet.Content
{
    internal class IntroScreen
    {
        Animation intro;

        public IntroScreen()
        {
            intro = new Animation(0, 6, 0.3f, 0);
        }

        public void AnimationStart(GameTime gameTime)
        {
            intro.Update(gameTime);
            intro.GetFrame();
        }
        





    }
}
