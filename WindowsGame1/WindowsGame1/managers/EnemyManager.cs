using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class EnemyManager : Drawable, Updatable, Loadable
    {

        BaseEnemy[] enemies;
        const int maxEnemyWidth = 15;

        public EnemyManager(int amount)
        {
            enemies = new BaseEnemy[amount];
            for (int i = 0; i < enemies.Length; i++)
            {
                switch (i / maxEnemyWidth)
                {
                    case 0:
                        enemies[i] = new StrongEnemy();
                        break;
                    case 1:
                        enemies[i] = new FastEnemy();
                        break;
                    case 2:
                        enemies[i] = new BaseEnemy();
                        break;
                    default:
                        enemies[i] = new BaseEnemy();
                        break;
                }
            }
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            int entityID = 0;
            foreach (BaseEnemy e in enemies)
            {
                if (entityID == 0 || entityID == (maxEnemyWidth-1))
                {
                    
                    // Change X direction when screen edge has been reached
                    if (e.getSafeBounds().Left == e.getPosition().X || e.getSafeBounds().Right - e.getTexture().Width == e.getPosition().X)
                    {
                        foreach (BaseEnemy e2 in enemies)
                        {
                            e2.setSpeed(e2.getSpeed().X * -1, e2.getSpeed().Y);
                        }
                    }
                }

                entityID++;
            }

            foreach (BaseEnemy e in enemies)
            {
                e.Update(gameTime);
            }
        }

        public void LoadContent()
        {
            int entityID = 0;
            foreach(BaseEnemy e in enemies) {
                
                // Calculate offset for enemy
                Console.WriteLine("Updating offset");
                e.setOffset(75.0f * (float)(entityID%maxEnemyWidth), 10.0f + (entityID / maxEnemyWidth)*50.0f);
                entityID++;

                e.LoadContent();
            }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (BaseEnemy e in enemies)
            {
                e.Draw(gameTime);
            }
        }

        protected void sideReached()
        {
            foreach (BaseEnemy e in enemies)
            {
                e.setSpeed(e.getSpeed().X * -1, e.getSpeed().Y);
            }
        }

        public Entity[] getEnemies()
        {
            return enemies;
        }
    }
}
