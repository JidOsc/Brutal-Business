using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Spelet
{
    
    internal class SoundManager
    {
        public static void PlaySound(Vector2 position, SoundEffect sound )
        {
            sound.Play();
        }

    }
} 
