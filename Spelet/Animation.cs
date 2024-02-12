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
        int 
            firstFrame, //första frame i animationen
            lastFrame, //sista 
            frameNumber, //nuvarande frame
            frameSize; //storlek på en frame (antar kvadrat)

        float 
            timeBetweenFrames, //tid det tar för animation att byta frame
            lastAnimationSecond = 0; //förra gången frame byttes

        Rectangle sourcerect;

        public Animation(int firstFrame, int lastFrame, float timeBetweenFrames, int frameSize)
        {
            this.firstFrame = this.frameNumber = firstFrame;
            this.lastFrame = lastFrame;

            this.frameSize = frameSize;
            
            this.timeBetweenFrames = timeBetweenFrames;

            sourcerect = new Rectangle(firstFrame * frameSize, 0, frameSize, frameSize);
            
        }
        public void Update(GameTime gameTime)
        {
            if(lastAnimationSecond + timeBetweenFrames < gameTime.TotalGameTime.TotalSeconds)
            { 
                frameNumber += 1;
                frameNumber %= lastFrame;

                if(frameNumber == 0)
                {
                    frameNumber += firstFrame;
                }

                lastAnimationSecond = (float)gameTime.TotalGameTime.TotalSeconds;
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
