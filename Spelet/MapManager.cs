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
        Player player;

        public Map map;
        Camera camera;
        RenderTarget2D mainTarget;


        public MapManager(short[][] map, GraphicsDevice _graphics)
        {

            //camera = new Camera(Data.viewport);
            mainTarget = new RenderTarget2D(_graphics, 1920, 1080);

            this.map = new Map(32, 10);
            this.map.InsertMap(map);

            enemyList = new List<Enemy>()
            {
                new Enemy(new Vector2 (325, 96), 1f)
            };
            pickupObjects = new List<PickupObject>()
            {
                new PickupObject(new Vector2(1430, 360), 0.5f),
                new PickupObject(new Vector2(1000, 700), 0.5f),
                new PickupObject(new Vector2(600, 520), 0.5f),
                new PickupObject(new Vector2(649, 550), 0.5f),
                new PickupObject(new Vector2(890, 400), 0.5f),
                new PickupObject(new Vector2(1186, 1010), 0.5f),
                new PickupObject(new Vector2(1200, 940), 0.5f),
                new PickupObject(new Vector2(1500, 400), 0.5f),
                new PickupObject(new Vector2(250, 1000), 0.5f),
                new PickupObject(new Vector2(592, 640), 0.5f),

                new PickupObject(Data.GridToWorld(new Vector2(3,3)), 0.5f)
            };
            player = new Player(Data.GridToWorld(new Vector2(3, 3)), 0.5f);
        }

        public void Update(GameTime _gameTime)
        {
            foreach(Enemy enemy in enemyList)
            {
                enemy.Update(_gameTime);
                enemy.SeesPlayer(player, map);
            }

            foreach(PickupObject pickupObject in pickupObjects)
            {
                //pickupObject.Update();

                if (player.CanPickUp(pickupObject))
                {
                    player.PickedUp(pickupObject);
                    pickupObjects.Remove(pickupObject);
                    break;
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
