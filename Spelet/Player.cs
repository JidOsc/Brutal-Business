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
        public Animation walkingAnimation, runningAnimation;
        float runningSpeed = 2;

        public Player(Vector2 position, float scale) : base(position, scale)
        {
            inventory = new List<PickupObject>();
            texture = Data.textures["player"];

            hitbox.Size = new Point((int)(texture.Width / 12 * scale), (int)(texture.Height * scale));

            walkingAnimation = new Animation(0, 0.2f, 5, 64);
            runningAnimation = new Animation(6, 0.2f, 11, 64);

            AdjustPosition();

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
            if (Data.keyboard.IsKeyDown(Keys.LeftShift))
            {
                velocity *= runningSpeed;
            }

            walkingAnimation.playAnimation = moving;
            position += velocity;

            walkingAnimation.Update(gameTime);
            runningAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();

            rotation = Data.RelationToRotation(Data.mouse.Position.ToVector2(), position) * -1;




        }

        public void Draw()
        {
            
            //lär inte behövas här
        }
    }
}
