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

        KeyboardState keyboard;

        public Player()
        {
            inventory = new List<PickupObject>();
        }

        public bool PicksUp()
        {
            return true;
            //kollar om knapp trycks på och skickar tillbaka true om den gör det
        }
        public bool Inventoryspace()
        {
            if (inventory.Count<
            {
                return true;
            }
        }       

        public void PickedUp(PickupObject pickedupobject)
        {
            //lägg till upplockat föremål i inventory
        }

        public void Update()
        {
            if (keyboard.IsKeyDown(Keys.S))
            {
                velocity.Y = speed;
            }
            else if (keyboard.IsKeyDown(Keys.W))
            {
                velocity.Y = -speed;
            }
            else
            {
                velocity.Y = 0;
            }
           
            if (keyboard.IsKeyDown(Keys.D))
            {
                velocity.X = -speed;
            }
            else if (keyboard.IsKeyDown(Keys.A))
            {
                velocity.X = speed;
            }
            else
            {
                velocity.X = 0;
            }

            position += velocity;
            
            






        }

        public void Draw()
        {
            //lär inte behövas här
        }
    }
}
