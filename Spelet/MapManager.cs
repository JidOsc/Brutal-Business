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
    internal class MapManager
    {
        List<Enemy> enemyList;
        
        List<PickupObject> pickupObjectList;
        public Player player;

        public Map map;
        Camera camera;
        RenderTarget2D mainTarget;
        public float TotalValue;

        public MapManager(Dictionary<string, short[][]> loadedMap, GraphicsDevice _graphics)
        {
            //camera = new Camera(Data.viewport);
            mainTarget = new RenderTarget2D(_graphics, 1920, 1080);

            this.map = new Map(32, 10);
            LoadMap(loadedMap);
        }

        void LoadMap(Dictionary<string, short[][]> loadedMap)
        {
            this.map.InsertMap(loadedMap["tilemap"]);
            InsertEntities(loadedMap["markers"]);
        }

        void InsertEntities(short[][] markers)
        {
            enemyList = new List<Enemy>();
            pickupObjectList = new List<PickupObject>();

            for(int x = 0; x < markers[0].Length; x++)
            {
                for(int y = 0; y < markers.Length; y++)
                {
                    switch (markers[y][x])
                    {
                        case 1: //pickupobject
                            pickupObjectList.Add(new PickupObject(Data.GridToWorld(new Vector2(x, y)), 0.5f));
                            break;

                        case 2: //spelare
                            player = new Player(Data.GridToWorld(new Vector2(x, y)), 0.5f);
                            break;

                        case 3: //fiende
                            enemyList.Add(new Enemy(Data.GridToWorld(new Vector2(x, y)), 0.9f));
                            break;
                    }
                }
            }
        }

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                if (enemy.lastTimeChecked + enemy.updateRate <= _gameTime.TotalGameTime.TotalMilliseconds)
                {
                    enemy.UpdateEnemyState(player, map);
                    enemy.lastTimeChecked = (float)_gameTime.TotalGameTime.TotalMilliseconds;

                    if (enemy.hitbox.Intersects(player.hitbox))
                    {
                        player.PlayerHit();
                    }
                }
                
                enemy.Update(_gameTime);
            }

            foreach(PickupObject pickupObject in pickupObjectList)
            {
                if (player.CanPickUp(pickupObject))
                {
                    player.PickedUp(pickupObject);
                    pickupObjectList.Remove(pickupObject);
                    break;

                }
                Vector2 Temppos = Data.WorldToGrid(pickupObject.position);
                if (map.foregroundTiles[(int)Temppos.Y][(int)Temppos.X] == 1)
                {
                    TotalValue += pickupObject.value;
                    
                    
                }
                if (map.foregroundTiles[(int)Temppos.Y][(int)Temppos.X] == 1)
                {
                    pickupObject.value = 0;
                }
            } 

            player.Update(_gameTime);
            /*camera.position = player.position;
            camera.UpdateCamera(Data.viewport);*/

            if (player.CanDrop())
            {
                pickupObjectList.Add(player.GetDroppedObject());
            }
        }

        public void Draw(SpriteBatch _spriteBatch, GraphicsDevice _graphics)
        {
            _graphics.SetRenderTarget(mainTarget);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp /*transformMatrix: camera.transform*/);
            map.Draw(_spriteBatch);
            _spriteBatch.DrawString( Data.money, TotalValue.ToString(),new Vector2(1700,10), Color.Green);
            

            foreach(Enemy enemy in enemyList)
            {
                enemy.Draw(_spriteBatch);
            }

            foreach(PickupObject pickupObject in pickupObjectList)
            {
                pickupObject.Draw(_spriteBatch);
            }

            player.Draw(_spriteBatch);
            _spriteBatch.End();

            _graphics.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(mainTarget, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.5f);
        }
    }
}
