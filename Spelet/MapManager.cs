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
    internal class MapManager
    {
        List<Enemy> enemyList;
        
        List<PickupObject> pickupObjects;
        Player player;

        public Map map;


        public MapManager()
        {
            map = new Map(32, 7);

            enemyList = new List<Enemy>()
            {
                new Enemy(new Vector2 (325, 96), 0.8f)
            };
            pickupObjects = new List<PickupObject>()
            {
                new PickupObject(new Vector2(500, 300), 0.5f),
                new PickupObject(Data.GridToWorld(new Vector2(3,3),16), 0.5f)
            };
            player = new Player(Data.GridToWorld(new Vector2(3, 3), 16), 0.5f);
        }

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                enemy.Update(_gameTime);
                
                if (enemy.SeesPlayer(player,map))
                {
                    enemy.ChasePlayer(player);
                }
                else
                {
                    enemy.Patrol(map);
                }
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                //pickupObject.Update();

                if (pickupObject.PlayerCanPickup(player))
                {
                    if (player.PicksUp())
                    {
                        player.PickedUp(pickupObject);
                        pickupObjects.Remove(pickupObject);
                        break;
                    }
                }
            }

            player.Update(_gameTime);

            if (player.TryingToDrop())
            {
                pickupObjects.Add(player.GetDroptObjekt());
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            map.Draw(_spriteBatch);

            foreach(Enemy enemy in enemyList)
            {
                enemy.Draw(_spriteBatch);
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                pickupObject.Draw(_spriteBatch);
            }

            player.Draw(_spriteBatch);
        }
    }
}
