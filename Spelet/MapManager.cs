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

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                //enemy.Update();

                /*if (enemy.SeesPlayer(player))
                {
                    enemy.ChasePlayer(player);
                }*/
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                //pickupObject.Update();

                /*if (pickupObject.PlayerCanPickup(player))
                {
                    if (player.PicksUp())
                    {
                        player.PickedUp(pickupObject);
                        pickupObjects.Remove(pickupObject);
                    }
                }*/
            }

            //player.Update();


        }
    }
}
