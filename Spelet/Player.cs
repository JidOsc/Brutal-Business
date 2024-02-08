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

            size = new Vector2(texture.Width / 6, texture.Height);

            walkingAnimation = new Animation(0, 0.01f, 5, 64);
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
        public bool TryingToDrop()
        {
            if (inventory.Count > 0 && Data.keyboard.IsKeyDown(Keys.R))
            {
                return true;
            }
            return false;
        }
        public PickupObject GetDroptObjekt()
        {
            PickupObject tempobject = inventory[0];
            inventory.Remove(tempobject);
            tempobject.position = position;
            return tempobject;

        }
        public void PickedUp(PickupObject pickedupobject)
        {
            inventory.Add(pickedupobject);
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

            if(Math.Abs(velocity.X) > 0||Math.Abs(velocity.Y) >0)
            {
                moving = true;
            }
            else
            {
                walkingAnimation.RestartAnimation();
                moving = false;
            }

            walkingAnimation.playAnimation = moving;
            position += velocity;

            walkingAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();

            rotation = Data.RelationToRotation(Data.mouse.Position.ToVector2(), position) * -1;




        }

        public void Draw()
        {
            
            //lär inte behövas här
        }
    }
}
