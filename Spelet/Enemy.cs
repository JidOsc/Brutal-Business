using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Spelet
{
    internal class Enemy : HPEntity
    {
        enum enemyStates { patrolling, tracking, chasing};
        enemyStates currentEnemyState = enemyStates.patrolling;

        float
            viewDistance = 200f,
            updateRate = 250f,
            lastTimeChecked = 0f;

        List<Vector2> directionalDirections = new List<Vector2>();

        Vector2
            direction;

        Vector2
            lastSeenPlayerPosition;

        Animation walkingAnimation;

        public Enemy(Vector2 position, float scale) : base(position, scale)
        {
            texture = Data.textures["enemy"];
            direction = new Vector2(1, 0);

            hitbox.Size = new Point((int)(texture.Height * scale), (int)(texture.Height * scale));

            speed = 1f;

            walkingAnimation = new Animation(0, 5, 0.3f, 64);
        }
        
        bool IsWallThere(Map map, Player player)
        {
            Vector2 positionB;
            Vector2 positionA;

            if (player.position.X > position.X)
            {
                positionA = Data.WorldToGrid(position);
                positionB = Data.WorldToGrid(player.position);
            }
            else
            {
                positionA = Data.WorldToGrid(player.position);
                positionB = Data.WorldToGrid(position);
            }

            for (int x = (int)positionA.X; x < positionB.X; x++)
            {
                int y = (int)(positionA.Y + (positionB.Y - positionA.Y) * (x - positionA.X) / (positionB.X - positionA.X));

                if (PositionIsValid(map, x, y) && Data.collisionMap[y, x])
                {
                    return true;
                }
            }
            return false;
        }

        bool PositionIsValid(Map map, int x, int y)
        {
            Debug.WriteLine(x >= 0 && x < map.foregroundTiles[0].Length && y >= 0 && y < map.foregroundTiles.Length);
            return x >= 0 && x < map.foregroundTiles[0].Length && y >= 0 && y < map.foregroundTiles.Length;
        }

        bool SeesPlayer(Player player, Map map)
        {
            float distanceToPlayer = Vector2.Distance(player.position, position);
            Debug.WriteLine(distanceToPlayer.ToString());

            return distanceToPlayer <= viewDistance && !IsWallThere(map, player);
        }

        public void UpdateEnemyState(Player player, Map map)
        {
            if(SeesPlayer(player, map))
            {
                lastSeenPlayerPosition = player.position;
                currentEnemyState = enemyStates.chasing;
            }
            else if(currentEnemyState == enemyStates.chasing)
            {
                currentEnemyState = enemyStates.tracking;
            }
            else if(Math.Abs(position.X - lastSeenPlayerPosition.X) < 2 && Math.Abs(position.Y - lastSeenPlayerPosition.Y) < 2)
            {
                currentEnemyState = enemyStates.patrolling;
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (currentEnemyState)
            {
                case enemyStates.patrolling:
                    Patrol();
                    break;

                case enemyStates.tracking:
                    TrackPlayer();
                    break;

                case enemyStates.chasing:
                    ChasePlayer();
                    break;
            }

            UpdateHitboxVelocity();

            rotation = Data.RelationToRotation(Vector2.Zero, velocity) * -1;

            walkingAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();
        }

        void Patrol()
        {
            if (controller.collisions.left || controller.collisions.right || controller.collisions.above || controller.collisions.below)
            {
                direction = GetNewDirection(GetAvailableDirections());
            }
            velocity = direction * speed;
        }

        Vector2 GetNewDirection(List<Vector2> availableDirections)
        {
            return availableDirections[Data.random.Next(0, availableDirections.Count)];
        }

        List<Vector2> GetAvailableDirections()
        {
            List<Vector2> directionalDirections = new List<Vector2>();

            if (!controller.collisions.left)
            {
                directionalDirections.Add(new Vector2(-1, 0));
            }
            if (!controller.collisions.right)
            {
                directionalDirections.Add(new Vector2(1, 0));
            }
            if (!controller.collisions.above)
            {
                directionalDirections.Add(new Vector2(0, -1));
            }
            if (!controller.collisions.below)
            {
                directionalDirections.Add(new Vector2(0, 1));
            }

            return directionalDirections;
        }

        void TrackPlayer()
        {
            velocity = Vector2.Normalize(position - lastSeenPlayerPosition) * speed * -1;
        }

        void ChasePlayer()
        {
            velocity = Vector2.Normalize(position - lastSeenPlayerPosition) * speed * -1;
        }
    }
}
