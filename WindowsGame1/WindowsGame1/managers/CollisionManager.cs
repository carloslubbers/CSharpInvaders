using SpaceInvaders.entities.ammo;
using SpaceInvaders.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.managers
{
    class CollisionManager : Updatable
    {
        BulletManager bulletManager;
        EnemyManager enemyManager;

        public CollisionManager(BulletManager _bulletManager, EnemyManager _enemyManager)
        {
            bulletManager = _bulletManager;
            enemyManager = _enemyManager;
        }
        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Ammo[] bullets = bulletManager.getPlayerBullets();
            BaseEnemy[] enemies = enemyManager.getEnemies();

            foreach (Ammo a in bullets)
            {
                if (a != null)
                {
                    if (a.active)
                    {
                        foreach (BaseEnemy e in enemies)
                        {
                            if (e != null)
                            {
                                if (e.active)
                                {
                                    if (a.textureComponent.bounds.Intersects(e.textureComponent.bounds))
                                    {
                                        a.active = false;
                                        e.active = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
