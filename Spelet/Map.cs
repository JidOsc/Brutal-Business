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
        public short[][] foregroundTiles = new short[][]
        {
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        short[][] backgroundTiles;

        public short
            tileSize;

        short
            sizeX,
            sizeY,
            amountOfColumns;

        Texture2D
            spritesheet;

        Rectangle 
            srcRect = new Rectangle();

        public Map(short tileSize, short amountOfColumns)
        {
            this.tileSize = tileSize;
            this.amountOfColumns = amountOfColumns;

            this.sizeX = (short)foregroundTiles[0].Length;
            this.sizeY = (short)foregroundTiles.Length;

            srcRect = new Rectangle(0, 0, tileSize, tileSize);
            spritesheet = Data.textures["tilemap"];
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for(int y = 0; y < sizeY; y++)
            {
                for(int x = 0; x < sizeX; x++)
                {
                    srcRect.X = (foregroundTiles[y][x] % amountOfColumns) * tileSize;
                    srcRect.Y = (foregroundTiles[y][x] / amountOfColumns) * tileSize;

                    _spriteBatch.Draw(spritesheet, new Vector2(x, y) * tileSize, srcRect, Color.White);
                }
            }
        }
    }
}
