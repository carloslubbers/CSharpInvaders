using System;
using SpaceInvaders.entities.ammo;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.entity
{
    public class FiringComponent : AbstractComponent
    {
        public String AmmoType = "default";
        readonly PositionComponent _pos;

        public FiringComponent(IEntity _base, PositionComponent pos)
        {
            _pos = pos;
        }

        public void Fire()
        {
            Ammo ammo;

            switch (AmmoType)
            {
                default:
                    ammo = new Ammo();
                    break;
            }
            Space.BulletManager.FirePlayerBullet(ammo, _pos.EntityPosition);
        }

        public void SetDelay(int d) {
            Space.BulletManager.SetDelay(d);
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) { }
    }
}
