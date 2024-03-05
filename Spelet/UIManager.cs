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
    internal class UIManager
    {
        InventoryView[] inventorybar;
        List<PickupObject> pickupObjects;

        Progressbar
            playerHealth,
            playerStamina;

        float totalValue;
        bool instructionsPresent;

        public UIManager()
        {
            inventorybar = new InventoryView[3];
            InitializeInventory();

            playerHealth = new Progressbar(Data.textures["Bar"], new Vector2(10, 10), new Vector2(50, 10), 5f, Data.textures["background"], Color.LawnGreen);
            playerStamina = new Progressbar(Data.textures["stamina_bar_capsule"], new Vector2(10, 85), new Vector2(50, 10), 5f, Data.textures["background"], Color.Orange);

            instructionsPresent = true;
        }

        public void Update(GameTime _gameTime, Player player, float totalValue)
        {
            pickupObjects = player.inventory;

            for(int i = 0; i < inventorybar.Length; i++)
            {
                if(pickupObjects.Count > i)
                {
                    inventorybar[i].Update(_gameTime, pickupObjects[i]);
                }
                else
                {
                    inventorybar[i].Update(_gameTime, null);
                }
            }

            this.totalValue = totalValue;

            playerStamina.SetNewValue(player.currentStamina);
            playerHealth.SetNewValue(player.health);
            
            playerStamina.Update(_gameTime);
            playerHealth.Update(_gameTime);
        }

        void InitializeInventory()
        {
            for(int i = 0; i < inventorybar.Length; i++)
            {
                inventorybar[i] = new InventoryView(new Vector2(500 + 200 * i, 700), new Vector2(100, 100));
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(Data.money, "Total value collected: " + totalValue.ToString(), new Vector2(Data.viewport.Width - 30, 10) * Data.cameraScale, Color.White);

            foreach(InventoryView inventory in inventorybar)
            {
               inventory.Draw(_spriteBatch);
            }

            if (instructionsPresent)
            {
                _spriteBatch.Draw(Data.textures["instructions"], new Vector2(200, 200), null, Color.White, 0, Vector2.Zero, 8, SpriteEffects.None, 0);
                if(Data.keyboard.GetPressedKeyCount() > 0)
                {
                    instructionsPresent = false;
                }
            }

            playerHealth.Draw(_spriteBatch);
            playerStamina.Draw(_spriteBatch);
        }
        
    }
    
}
