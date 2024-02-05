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

        Random random = new Random();

        Map map;

        public MapManager()
        {
            map = new Map(32, 6);
        }

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                //enemy.Update();
                
                if (enemy.SeesPlayer(player))
                {
                    enemy.ChasePlayer(player);
                }
                else
                {
                    //enemy.Patrol(map.foregroundTiles);
                }
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                //pickupObject.Update();

                /*if (pickupObject.PlayerCanPickup(player))
                {*/
                    if (player.PicksUp())
                    {
                        player.PickedUp(pickupObject);
                        pickupObjects.Remove(pickupObject);
                    }
                //}
            }

            //player.Update();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            map.Draw(_spriteBatch);

            foreach(Enemy enemy in enemyList)
            {
                //enemy.Draw();
            }
        }
    }
}
