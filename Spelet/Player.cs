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
        public PickupObject[] inventory;
        short inventorySize = 3;

        public Player()
        {
            inventory = new PickupObject[inventorySize];
        }

        public bool PicksUp()
        {
            return true;
            //kollar om knapp trycks på och skickar tillbaka true om den gör det
        }

        public void PickedUp(PickupObject pickedupobject)
        {
            //lägg till upplockat föremål i inventory
        }

        public void Update()
        {
            //kolla om spelaren går
        }

        public void Draw()
        {
            //lär inte behövas här
        }
    }
}
