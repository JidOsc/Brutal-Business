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
        
        List<PickupObject> pickupObjects;
        public Player player;

        public Map map;
        Camera camera;
        RenderTarget2D mainTarget;
        public float TotalValue;

        public MapManager(short[][] map, GraphicsDevice _graphics)
        {

            //camera = new Camera(Data.viewport);
            mainTarget = new RenderTarget2D(_graphics, 1920, 1080);

            this.map = new Map(32, 10);
            this.map.InsertMap(map);
            

            enemyList = new List<Enemy>()
            {
                new Enemy(Data.GridToWorld(new Vector2(13, 13) + new Vector2(1, 1)), 0.9f),
                new Enemy(Data.GridToWorld(new Vector2(28, 5) + new Vector2(1, 1)), 0.9f),
                new Enemy(Data.GridToWorld(new Vector2(20, 25)), 0.9f)
            };
            pickupObjects = new List<PickupObject>()
            {
                new PickupObject(new Vector2(1430, 360), 1f),
                new PickupObject(new Vector2(1000, 700), 1f),
                new PickupObject(new Vector2(600, 520), 1f),
                new PickupObject(new Vector2(649, 550), 1f),
                new PickupObject(new Vector2(890, 400), 1f),
                new PickupObject(new Vector2(1186, 1010), 1f),
                new PickupObject(new Vector2(1200, 940), 1f),
                new PickupObject(new Vector2(1500, 400), 1f),
                new PickupObject(new Vector2(250, 1000), 1f),
                new PickupObject(new Vector2(592, 640), 1f),

                new PickupObject(Data.GridToWorld(new Vector2(3,3)), 1f)
                
                
            
            };
            player = new Player(Data.GridToWorld(new Vector2(3, 3)), 0.5f);
           
        }

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                if (enemy.lastTimeChecked + enemy.updateRate <= _gameTime.TotalGameTime.TotalMilliseconds)
                {
                    enemy.UpdateEnemyState(player, map);
                    enemy.lastTimeChecked = (float)_gameTime.TotalGameTime.TotalMilliseconds;
                }
                
                enemy.Update(_gameTime);
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                if (player.CanPickUp(pickupObject))
                {
                    player.PickedUp(pickupObject);
                    pickupObjects.Remove(pickupObject);
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
                pickupObjects.Add(player.GetDroppedObject());
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

            foreach(PickupObject pickupObject in pickupObjects)
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
