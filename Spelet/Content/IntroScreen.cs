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
        Animation introAnimation;


        public IntroScreen()
        {
            introAnimation = new Animation(0, 4, 0.3f, 96);
        }

        public void AnimationStart()
        {
            introAnimation.GetFrame();
            
        }
        
        public void Update(GameTime gameTime)
        {
            introAnimation.GetFrame();
        }




    }
}
