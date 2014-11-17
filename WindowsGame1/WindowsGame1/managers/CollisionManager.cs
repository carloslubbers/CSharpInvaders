using SpaceInvaders.entities.components;
using SpaceInvaders.entities.@interface;
using SpaceInvaders.world;
using System.Linq;

namespace SpaceInvaders.managers
{
    class CollisionManager : IUpdatable
    {
        readonly BulletManager _bulletManager;
        readonly EnemyManager _enemyManager;

        public CollisionManager(BulletManager bulletManager, EnemyManager enemyManager)
        {
            _bulletManager = bulletManager;
            _enemyManager = enemyManager;
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            var bullets = _bulletManager.GetPlayerBullets();
            var enemies = _enemyManager.GetEnemies();

            foreach (var a in bullets)
            {
                if (a == null || !a.Active) continue;
                var a1 = a;
                foreach (var e in from e in enemies where e != null && e.Active let tc = (TextureComponent) e.Components["texture"] where a1.TextureComponent.Bounds.Intersects(tc.Bounds) select e)
                {
                    a.Active = false;
                    e.Active = false;
                    Space.SoundManager.Play("invaderkilled", 0.01f);
                    Space.ScoreManager.AddScore(1);
                }
            }
        }
    }
}
