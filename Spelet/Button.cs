using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class Button : UIelement
    {
        Color CurrentColor, StartColor = Color.Black;

        public Button(Vector2 position, Vector2 size)
        {
            this.position = position;
        }

        public void Update()
        {
            if (IsInside(Data.mouse.Position.ToVector2()))
            {
                CurrentColor = StartColor * 0.6f;
            }
        }
    }

  
}

