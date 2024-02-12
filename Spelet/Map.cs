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
        public short[][] foregroundTiles;
        short[][] backgroundTiles;

        public int
            tileSize;

        short
            sizeX,
            sizeY,
            amountOfColumns;

        Texture2D
            spritesheet;

        Rectangle 
            srcRect = new Rectangle();

        public Map(int tileSize, short amountOfColumns)
        {
            this.tileSize = Data.tileSize = tileSize;

            this.amountOfColumns = amountOfColumns;

            srcRect = new Rectangle(0, 0, tileSize, tileSize);
            spritesheet = Data.textures["tilemap"];
        }

        public void InsertMap(short[][] map)
        {
            foregroundTiles = map;

            this.sizeX = (short)foregroundTiles[0].Length;
            this.sizeY = (short)foregroundTiles.Length;

            CreateCollisionMap();
        }

        public void CreateCollisionMap()
        {
            Data.collisionMap = new bool[sizeY, sizeX];
            for (int x = 0; x < sizeX; x++)
            {
                for(int y = 0; y < sizeY; y++)
                {
                    if (foregroundTiles[y][x] > Data.firstCollision)
                    {
                        Data.collisionMap[y, x] = true;
                    }
                    else
                    {
                        Data.collisionMap[y, x] = false;
                    }
                }
            }
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
