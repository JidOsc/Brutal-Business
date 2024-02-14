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
            background = Data.textures["inventory_frame"];
        }

        public void Update(GameTime _gameTime, PickupObject pickupObject)
        {
            this.pickupObject = pickupObject;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, hitbox, Color.White);

            if(pickupObject != null)
            {
                Vector2 offset = hitbox.Size.ToVector2() / 2 - pickupObject.texture.Bounds.Size.ToVector2() / 2;
                _spriteBatch.Draw(pickupObject.texture, hitbox, Color.White);
            }
        }
    }
}
