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

        Progressbar
            playerHealth,
            playerStamina;

        public UIManager()
        {
            inventorybar = new InventoryView[3];
        }

        public void Update(GameTime _gameTime, Player player)
        {
            
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
