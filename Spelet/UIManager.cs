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
        List<InventoryView> inventorybar = new List<InventoryView>();

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach(InventoryView inventory in inventorybar)
            {
                inventory.Draw(_spriteBatch);
            }
        }
        
    }
    
}
