using SpaceInvaders.entities.ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class FiringComponent
    {
        public String ammoType = "default";
        PositionComponent pos;

        public FiringComponent(Entity _base, PositionComponent _pos)
        {
            pos = _pos;
        }

        public void Fire()
        {
            Ammo ammo;

            switch (ammoType)
            {
                default:
                    ammo = new Ammo();
                    break;
            }
            Space.bulletManager.createPlayerBullet(new Ammo(), pos.entityPosition);
        }
    }
}
