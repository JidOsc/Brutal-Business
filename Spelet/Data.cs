using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;

namespace Spelet
{
    internal class Data
    {
        public static Random random = new Random();

        public static KeyboardState 
            keyboard, 
            lastKeyboard;

        public static MouseState 
            mouse, 
            lastMouse;

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
        {
            {"player", null },
            {"enemy", null },
            {"tilemap", null },
            {"gear", null },
            {"background", null },
            {"buttonstart", null},
            {"Bar",null },
            {"broken_combat_knife", null },
            {"credits_button", null },
            {"credits_menu", null },
            {"dark_catcher_egg", null },
            {"endbutton", null },
            {"inventory_frame", null },
            {"mystery_bottle", null },
            {"settings_button", null },
            {"stamina_bar_capsule", null },
            {"titel", null },
            {"boarattack", null }

        };

        public static Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>()
        {
            {"mixkit-horror-ambience-2482",null },
            {"mixkit-footsteps-in-a-tunnel-loop-543",null },
            {"mixkit-angry-dragon-growl-309",null },
            {"mixkit-big-wild-cat-slow-moan-90",null },
            {"mixkit-sphinx-cat-purr-and-quiet-growl-3092",null },
            {"mixkit-horror-impact-773",null },
            {"mixkit-haunted-slow-orchestra-634",null }
        };

        public static int tileSize;
        public static int cameraScale;

        public static SpriteFont money;

        public static Viewport viewport;

        public static bool[,] collisionMap;

        public static int firstCollision = 6;

        public static void LoadContent(ContentManager _contentManager)
        {
            foreach (string imagename in textures.Keys)
            {
                textures[imagename] = _contentManager.Load<Texture2D>(imagename);
            }
            foreach(string soundname in soundEffects.Keys)
            {
                soundEffects[soundname] = _contentManager.Load<SoundEffect>(soundname);
            }
            //loopa igenom dictionary för att med hjälp av contentmanager ladda in alla texturer
        }

        public static float RelationToRotation(Vector2 firstPos, Vector2 secondPos)
        {
            return (float)Math.Atan2(firstPos.X - secondPos.X, firstPos.Y - secondPos.Y);
        }

        public static Vector2 WorldToGrid(Vector2 position)
        {
            return new Vector2((int)(position.X / Data.tileSize),(int)(position.Y / Data.tileSize));
        }

        public static Vector2 GridToWorld(Vector2 position)
        {
            return new Vector2((int)(position.X * Data.tileSize), (int)(position.Y * Data.tileSize));
        }
    }
}
