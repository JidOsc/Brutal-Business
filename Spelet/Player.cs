using System;
using System.Collections.Generic;
using System.Data;
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
        enum playerStates { idle, walking, running };
        playerStates currentPlayerState = playerStates.idle;

        public List<PickupObject> inventory;
        public short inventorySize = 3;

        public Animation 
            walkingAnimation, 
            runningAnimation;

        float 
            runningModifier = 2;

        public float
            currentStamina = 5f,
            maxStamina = 5f,
            staminaDepletionRate = 0.05f;

        float
            lastTimesoundplay = 0,
            timebetwensound = 8; 

        public Player(Vector2 position, float scale) : base(position, scale)
        {
            inventory = new List<PickupObject>();
            texture = Data.textures["player"];

            health = 5;
            hitbox.Size = new Point((int)(texture.Height * scale), (int)(texture.Height * scale));

            walkingAnimation = new Animation(0, 6, 0.2f, 64);
            runningAnimation = new Animation(7, 11, 0.2f, 64);
        }

        public bool CanPickUp(PickupObject pickupObject)
        {
            return inventory.Count < inventorySize && Data.keyboard.IsKeyDown(Keys.E) && hitbox.Intersects(pickupObject.hitbox);
        }

        public void PickedUp(PickupObject pickupobject)
        {
            inventory.Add(pickupobject); //lägg till upplockat föremål i inventory
        }

        public bool CanDrop()
        {
            return inventory.Count > 0 && Data.keyboard.IsKeyDown(Keys.R) && !Data.lastKeyboard.IsKeyDown(Keys.R);
        }

        public PickupObject GetDroppedObject()
        {
            PickupObject tempobject = inventory[0];
            inventory.Remove(tempobject);
          
            tempobject.position = position;
            tempobject.hitbox.Location = position.ToPoint();

            return tempobject;
        }
        
        public bool IsDead()
        {
           return health <= 0;
        }

        public void PlayerHit()
        {
            TakeDamage(0.4f);
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            if (Data.keyboard.IsKeyDown(Keys.W)) //uppåt
            {
                velocity.Y = -speed;
            }
            else if (Data.keyboard.IsKeyDown(Keys.S)) //ner
            {
                velocity.Y = speed;
            }
            else
            {
                velocity.Y = 0;
            }
           
            if (Data.keyboard.IsKeyDown(Keys.A)) //vänster
            {
                velocity.X = -speed;
            }
            else if (Data.keyboard.IsKeyDown(Keys.D)) //höger
            {
                velocity.X = speed;
            }
            else
            {
                velocity.X = 0;
            }

            if(Math.Abs(velocity.X) > 0 || Math.Abs(velocity.Y) > 0)
            {
                if (lastTimesoundplay + timebetwensound < gameTime.TotalGameTime.TotalSeconds)
                {
                    lastTimesoundplay = (float)gameTime.TotalGameTime.TotalSeconds;
                    SoundManager.PlaySound(position, Data.soundEffects["mixkit-footsteps-in-a-tunnel-loop-543"]);

                }
                if (Data.keyboard.IsKeyDown(Keys.LeftShift) && currentStamina > 0)
                {
                    currentPlayerState = playerStates.running;
                    velocity *= runningModifier;
                    currentStamina -= staminaDepletionRate;
                }
                else
                {
                    currentPlayerState = playerStates.walking;

                    if (currentStamina < maxStamina && Data.keyboard.IsKeyDown(Keys.LeftShift) == false)
                    {
                        currentStamina += 0.5f * staminaDepletionRate;
                    }
                }
            }
            else
            {
                walkingAnimation.RestartAnimation();
                runningAnimation.RestartAnimation();

                currentPlayerState = playerStates.idle;

                if (currentStamina < maxStamina && Data.keyboard.IsKeyDown(Keys.LeftShift) ==false)
                {
                    currentStamina += staminaDepletionRate;
                }
            }

            switch (currentPlayerState)
            {
                case playerStates.walking:
                    walkingAnimation.Update(gameTime);
                    sourceRectangle = walkingAnimation.GetFrame();
                    break;

                case playerStates.running:
                    runningAnimation.Update(gameTime);
                    sourceRectangle = runningAnimation.GetFrame();
                    break;

                case playerStates.idle:
                    sourceRectangle = walkingAnimation.GetFrame();
                    break;
            }
                      
            UpdateHitboxVelocity();
            rotation = Data.RelationToRotation((Data.mouse.Position.ToVector2() + camera.position) / Data.cameraScale, position + new Vector2(texture.Height/2, texture.Height / 2)) * -1;
        }
    }
}
