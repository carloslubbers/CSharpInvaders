using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;
using System.Linq;

namespace SpaceInvaders.managers
{
    class CollisionManager : IUpdatable
    {
        private readonly Space _space;
        readonly BulletManager _bulletManager;
        readonly EnemyManager _enemyManager;

        public CollisionManager(Space space, BulletManager bulletManager, EnemyManager enemyManager)
        {
            _space = space;
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
                foreach (var e in from e in enemies where e != null && e.Active let tc = (TextureComponent) e.GetComponent<TextureComponent>() where a1.GetComponent<TextureComponent>().Bounds.Intersects(tc.Bounds) select e)
                {
                    a.Active = false;
                    e.Active = false;
                    _space.SoundManager.Play("invaderkilled", 0.01f);
                    _space.ScoreManager.AddScore(1);
                }
            }
        }
    }
}
