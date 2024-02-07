using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Spelet
{
    internal class Enemy : HPEntity
    {
        float viewDistance = 1.1f;

        List<Vector2> directionalDirections = new List<Vector2>();

        Vector2 direction;

        Animation walkingAnimation;

        public Enemy(Vector2 position)
        {
            texture = Data.textures["enemy"];
            direction = new Vector2(1, 0);
            this.position = position;
            speed = 1f;

            walkingAnimation = new Animation(0, 0.3f, 5, 64);
        }

        public bool SeesPlayer(Player player)
        {
            float distanceToPlayer = (float)Math.Sqrt(Math.Pow(player.position.X - position.X, 2) + Math.Pow(player.position.Y - position.Y, 2));

            if (distanceToPlayer <= viewDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChasePlayer(Player player)
        {
            velocity = Vector2.Normalize(position - player.position) * speed * -1;
        }

        public void Patrol(Map map)
        {
            Vector2 currentTilePosition = Data.WorldToGrid(position, map.tileSize);

            Debug.WriteLine(currentTilePosition);

            if(map.foregroundTiles[(int)(currentTilePosition.Y + direction.Y)][(int)(currentTilePosition.X + direction.X)] > 0)
            {
                //om ruta inte är ledig
                direction = GetNewDirection(GetAvailableDirections(map));
            }
            
            velocity = direction * speed;

        }
        
        public List<Vector2> GetAvailableDirections(Map map)
        {
            List<Vector2> directionalDirections = new List<Vector2>();
            Vector2 posInGrid = Data.WorldToGrid(position, map.tileSize);
            
            if (map.foregroundTiles[(int)(posInGrid.Y)][(int)posInGrid.X - 1] == 0)
            {
                directionalDirections.Add(new Vector2(-1, 0));
                //Vänster
            }
           
            
                if (map.foregroundTiles[(int)(posInGrid.Y - 1)][(int)posInGrid.X] == 0)
                {
                    directionalDirections.Add(new Vector2(0, -1));
                    //Upp
                }
           


            if (map.foregroundTiles[(int)(posInGrid.Y)][(int)posInGrid.X + 1] == 0)
            {
                directionalDirections.Add(new Vector2(1, 0));
                //Höger
            }

            if (map.foregroundTiles[(int)(posInGrid.Y + 1)][(int)posInGrid.X] == 0)
            {
                directionalDirections.Add(new Vector2(0, 1));
                //Ner
            }
            return directionalDirections;
        }

        public Vector2 GetNewDirection(List<Vector2> availableDirections)
        {
            return availableDirections[Data.random.Next(0, availableDirections.Count)];
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            walkingAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();
        }


    }
}
