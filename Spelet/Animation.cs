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
        

        bool spelAnimation; //ska animation spelas
        
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
            this.firstFrame = firstFrame;
            this.lastFrame = lastFrame;

            this.frameNumber = firstFrame;
            this.frameSize = frameSize;
            
            
            this.timeBetweenFrames = timeBetweenFrames;

            sourcerect = new Rectangle(firstFrame*frameSize,0,frameSize,frameSize);
            
        }
        public void Update(GameTime gameTime)
        {
            if(lastAnimationSecond + timeBetweenFrames < gameTime.TotalGameTime.TotalSeconds)
            {
                
                
                if (spelAnimation)
                {
                    frameNumber += 1;

                    frameNumber %= (short)(lastFrame - firstFrame + 1);

                    lastAnimationSecond = (float)gameTime.TotalGameTime.TotalSeconds;
                }
            }
        }
        
        public Rectangle GetFrame()
        {
            return sourcerect;
        }

    }
}
