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
    internal class Enemy : HPEntity
    {
        float viewDistance = 1.1f;

        List<Vector2> directionalDirections = new List<Vector2>();

        Vector2 direction;

        public Enemy(Vector2 position)
        {
            texture = Data.textures["enemy"];
            direction = new Vector2(1, 0);
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

            if(map.foregroundTiles[(int)(currentTilePosition.Y + direction.Y)][(int)(currentTilePosition.X + direction.X)] > 0)
            {
                //om ruta inte är ledig
                direction = GetNewDirection(GetAvailableDirections(map.foregroundTiles));
            }
            
            velocity = direction * speed;

        }
        
        public List<Vector2> GetAvailableDirections(short[][] obstacles)
        {
            List<Vector2> directionalDirections = new List<Vector2>();

            if (obstacles[(int)(position.X - 1)][(int)position.Y] == 0)
            {
                directionalDirections.Add(new Vector2(-1, 0));
                //Vänster
            }

           
            if (obstacles[(int)(position.Y - 1)][(int)position.Y] == 0)
            {
                directionalDirections.Add(new Vector2(0, -1));
                //Upp
            }


            if (obstacles[(int)(position.X + 1)][(int)position.Y] == 0)
            {
                directionalDirections.Add(new Vector2(1, 0));
                //Höger
            }

            if (obstacles[(int)(position.Y + 1)][(int)position.Y] == 0)
            {
                directionalDirections.Add(new Vector2(0, 1));
                //Ner
            }
            return directionalDirections;
        }

        public Vector2 GetNewDirection(List<Vector2> availableDirections)
        {
            return availableDirections[Data.random.Next(0, availableDirections.Count + 1)];
        }

        public void Update()
        {
            position += velocity;
        }


    }
}
