using System;
using SpaceInvaders.entities.ammo;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class FiringComponent : AbstractComponent
    {
        private const String AmmoType = "default";

        public FiringComponent(Entity baseEntity) : base(baseEntity)
        {
        }

        public void Fire()
        {
            Ammo ammo;

            switch (AmmoType)
            {
                default:
                    ammo = new Ammo(BaseEntity.Space);
                    break;
            }
            BaseEntity.Space.BulletManager.FirePlayerBullet(ammo, BaseEntity.GetComponent<PositionComponent>().EntityPosition);
        }

        public void SetDelay(int d) {
            BaseEntity.Space.BulletManager.SetDelay(d);
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) { }
    }
}
