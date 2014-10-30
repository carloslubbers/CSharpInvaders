using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class EnemyManager : Drawable, Updatable, Loadable
    {

        BaseEnemy[] enemies;
        const int maxEnemyWidth = 5;
        public EnemyManager(BaseEnemy[] _enemies)
        {
            enemies = _enemies;
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (BaseEnemy e in enemies)
            {
                e.Update(gameTime);


                // Change X direction when screen edge has been reached
                if (e.getSafeBounds().Left == e.getPosition().X || e.getSafeBounds().Right - e.getTexture().Width == e.getPosition().X)
                {
                    foreach (BaseEnemy e2 in enemies)
                    {
                        e2.setSpeed(e2.getSpeed().X * -1, e2.getSpeed().Y);
                    }
                }
            }
        }

        public void LoadContent(Microsoft.Xna.Framework.Graphics.Viewport _viewport)
        {
            int entityID = 0;
            foreach(BaseEnemy e in enemies) {
                e.setOffset(75.0f * (float)(entityID%maxEnemyWidth), (entityID / maxEnemyWidth)*50.0f);
                Console.WriteLine(entityID);
                entityID++;

                Console.WriteLine("Loading enemy " + entityID);
                e.LoadContent(_viewport);
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
    }
}
