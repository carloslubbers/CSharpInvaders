using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
                   /** case 0:
                        enemies[i] = new StrongEnemy();
                        break;
                    case 1:
                        enemies[i] = new FastEnemy();
                        break;
                    case 2:
                        enemies[i] = new BaseEnemy();
                        break;*/
                    default:
                        enemies[i] = new BaseEnemy();
                        break;
                }
            }

        }

        public void Initialize()
        {
            foreach (BaseEnemy e in enemies)
            {
                e.Initialize();
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
                    if (e.boundaryComponent.getSafeBounds().Left == e.positionComponent.entityPosition.X || e.boundaryComponent.getSafeBounds().Right - e.textureComponent.texture.Width == e.positionComponent.entityPosition.X)
                    {
                        foreach (BaseEnemy e2 in enemies)
                        {
                            e2.positionComponent.entitySpeed.X = e2.positionComponent.entitySpeed.X * -1;
                        }
                    }
                }

                entityID++;
            }

            foreach (BaseEnemy e in enemies)
            {
                KeyboardState ks = Keyboard.GetState(PlayerIndex.One);
                if (ks.IsKeyDown(Keys.R))
                {
                    foreach (BaseEnemy _e in enemies)
                    {
                        if (_e != null)
                        {
                            _e.active = true;
                        }
                    }
                }
                e.Update(gameTime);
            }
        }

        public void LoadContent()
        {
            int entityID = 0;
            foreach(BaseEnemy e in enemies) {
                
                // Calculate offset for enemy
                e.offsetComponent.setOffset(75.0f * (float)(entityID % maxEnemyWidth), 10.0f + (entityID / maxEnemyWidth) * 50.0f);
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
                e.positionComponent.entitySpeed.X = e.positionComponent.entitySpeed.X * -1;
            }
        }

        public BaseEnemy[] getEnemies()
        {
            return enemies;
        }
    }
}
