using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class InventoryView : UIElement
    {
        PickupObject pickupObject;

        public InventoryView(Vector2 position, Vector2 size) : base(position, size)
        {

        }

        public void Update(GameTime _gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, hitbox, Color.White);

            if(pickupObject != null)
            {
                _spriteBatch.Draw(pickupObject.texture, position, Color.White);
            }
        }
    }
}
