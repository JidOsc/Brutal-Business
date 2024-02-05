using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spelet
{
    internal class Map
    {
        short[][] foregroundTiles;
        short[][] backgroundTiles;

        short 
            sizeX,
            sizeY;

        public void Draw(SpriteBatch _spriteBatch)
        {
            for(int y = 0; y < sizeY; y++)
            {
                for(int x = 0; x < sizeX; x++)
                {
                    _spriteBatch.Draw();
                }
            }
        }
    }
}
