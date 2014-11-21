using System;
using SpaceInvaders.entities.ammo;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.components
{
    public class FiringComponent : AbstractComponent
    {
        private const String AmmoType = "default";
        private readonly Entity _base;
        readonly PositionComponent _pos;

        public FiringComponent(Entity _base, PositionComponent pos)
        {
            this._base = _base;
            _pos = pos;
        }

        public void Fire()
        {
            Ammo ammo;

            switch (AmmoType)
            {
                default:
                    ammo = new Ammo(_base.Space);
                    break;
            }
            _base.Space.BulletManager.FirePlayerBullet(ammo, _pos.EntityPosition);
        }

        public void SetDelay(int d) {
            _base.Space.BulletManager.SetDelay(d);
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) { }
    }
}
