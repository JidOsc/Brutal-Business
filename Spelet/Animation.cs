using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class Animation
    {
        

        public bool playAnimation; //ska animation spelas
        
        short 
            firstFrame, //första frame i animationen
            lastFrame, //sista 
            frameNumber, //nuvarande frame
            frameSize; //storlek på en frame (antar kvadrat)

        float 
            timeBetweenFrames, //tid det tar för animation att byta frame
            lastAnimationSecond = 0; //förra gången frame byttes

        Rectangle sourcerect;

        public Animation(short firstFrame,float timeBetweenFrames,short lastFrame,short frameSize)
        {
            playAnimation = true;

            this.firstFrame = firstFrame;
            this.lastFrame = lastFrame;

            this.frameNumber = firstFrame;
            this.frameSize = frameSize;
            
            
            this.timeBetweenFrames = timeBetweenFrames;

            sourcerect = new Rectangle(firstFrame*frameSize, 0, frameSize, frameSize);
            
        }
        public void Update(GameTime gameTime)
        {
            if(lastAnimationSecond + timeBetweenFrames < gameTime.TotalGameTime.TotalSeconds)
            { 
                if (playAnimation)
                {
                    frameNumber += 1;
                    frameNumber %= (short)(lastFrame + 1);
                    frameNumber += firstFrame;
                    lastAnimationSecond = (float)gameTime.TotalGameTime.TotalSeconds;
                }
            }
        }

        public void RestartAnimation()
        {
            frameNumber = firstFrame;
        }
        
        public Rectangle GetFrame()
        {
            sourcerect.Location = new Point(frameNumber * frameSize, 0);
            return sourcerect;
        }

    }
}
