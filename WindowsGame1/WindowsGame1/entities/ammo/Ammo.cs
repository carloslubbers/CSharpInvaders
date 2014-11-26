using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : AbstractAmmo
    {
        
        public Ammo(Space space) : base(space)
        {
            ((TextureComponent)Components["texture"]).SetTexture("ammoTexture");
            ((PositionComponent)Components["position"]).EntitySpeed.Y = -15.0f;
        }
    }
}
