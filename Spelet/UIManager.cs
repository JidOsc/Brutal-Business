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

        public UIManager()
        {
            inventorybar = new InventoryView[3];
            InitializeInventory();

            playerHealth = new Progressbar(Data.textures["healthbar"], new Vector2(10, 10), new Vector2(50, 10), 5f, Data.textures["background"]);
            playerStamina = new Progressbar(Data.textures["healthbar"], new Vector2(10, 10), new Vector2(50, 10), 5f, Data.textures["background"]);
        }

        public void Update(GameTime _gameTime, Player player)
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
            foreach(InventoryView inventory in inventorybar)
            {
               inventory.Draw(_spriteBatch);
            }

            playerHealth.Draw(_spriteBatch);
            playerStamina.Draw(_spriteBatch);
        }
        
    }
    
}
