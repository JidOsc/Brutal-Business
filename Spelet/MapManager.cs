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
        public short objectsLeft;

        public Player player;

        public Map map;
        Camera camera;
        RenderTarget2D mainTarget;
        public float totalValue;

        public MapManager(Dictionary<string, short[][]> loadedMap, GraphicsDevice _graphics)
        {
            Data.viewport.Width = 1920 / Data.cameraScale;
            Data.viewport.Height = 1080 / Data.cameraScale;

            camera = new Camera(Data.viewport);

            mainTarget = new RenderTarget2D(_graphics, 1920, 1080);
            totalValue = 0;
            objectsLeft = 0;

            this.map = new Map(32, 10);
            LoadMap(loadedMap);
        }

        public void Restart(Dictionary<string, short[][]> loadedMap)
        {
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
                            pickupObjectList.Add(new PickupObject(Data.GridToWorld(new Vector2(x, y)), 1f));
                            objectsLeft += 1;
                            break;

                        case 2: //spelare
                            player = new Player(Data.GridToWorld(new Vector2(x, y)), 0.4f);
                            break;

                        case 3: //fiende
                            enemyList.Add(new Enemy(Data.GridToWorld(new Vector2(x, y)), 0.8f));
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
                    enemy.UpdateEnemyState(player, map, _gameTime);
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

                if (map.foregroundTiles[(int)Temppos.Y][(int)Temppos.X] == 1 && pickupObject.value > 0)
                {
                    totalValue += pickupObject.value;
                    pickupObject.value = 0;
                    objectsLeft -= 1;
                }
            } 

            player.Update(_gameTime);
            
            camera.position = player.position * Data.cameraScale - Data.viewport.Bounds.Size.ToVector2() * 2;
            camera.UpdateCamera(Data.viewport);

            if (player.CanDrop())
            {
                pickupObjectList.Add(player.GetDroppedObject());
            }
        }

        public void Draw(SpriteBatch _spriteBatch, GraphicsDevice _graphics)
        {
            _graphics.SetRenderTarget(mainTarget);
            map.Draw(_spriteBatch);

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
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: camera.transform);
            _spriteBatch.Draw(mainTarget, Vector2.Zero, null, Color.White, 0, Vector2.Zero, Data.cameraScale, SpriteEffects.None, 0.5f);
            _spriteBatch.Draw(Data.textures["background"], Vector2.Zero, mainTarget.Bounds, Color.Black * Data.darkness, 0, Vector2.Zero, Data.cameraScale, SpriteEffects.None, 0.4f);
            _spriteBatch.End();
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        }
    }
}
