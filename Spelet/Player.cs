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
    internal class Player : HPEntity
    {
        public List<PickupObject> inventory;
        public short inventorySize = 3;
        public Animation walkingAnimation;

        public Player()
        {
            inventory = new List<PickupObject>();
            texture = Data.textures["player"];

            walkingAnimation = new Animation(0, 0.3f, 5, 64);
        }

        public bool PicksUp()
        {
            if (Data.keyboard.IsKeyDown(Keys.E))
            {
                return true;
            }
            return false;
            //kollar om knapp trycks på och skickar tillbaka true om den gör det
        }
        public bool HasInventorySpace()
        {
            if (inventory.Count < inventorySize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       

        public void PickedUp(PickupObject pickedupobject)
        {
            //inventory.Add += 1;
            //lägg till upplockat föremål i inventory
        }

        public void Update(GameTime gameTime)
        {
            if (Data.keyboard.IsKeyDown(Keys.S))
            {
                velocity.Y = speed;
            }
            else if (Data.keyboard.IsKeyDown(Keys.W))
            {
                velocity.Y = -speed;
            }
            else
            {
                velocity.Y = 0;
            }
           
            if (Data.keyboard.IsKeyDown(Keys.D))
            {
                velocity.X = speed;
            }
            else if (Data.keyboard.IsKeyDown(Keys.A))
            {
                velocity.X = -speed;
            }
            else
            {
                velocity.X = 0;
            }

            position += velocity;

            walkingAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();
            




        }

        public void Draw()
        {
            
            //lär inte behövas här
        }
    }
}
