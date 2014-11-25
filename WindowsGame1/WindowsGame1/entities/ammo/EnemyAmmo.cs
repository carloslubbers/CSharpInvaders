using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    class EnemyAmmo : AbstractAmmo
    {
        public EnemyAmmo(Space space) : base(space)
        {
            ((TextureComponent)Components["texture"]).SetTexture("enemy1Texture");
            ((PositionComponent)Components["position"]).EntitySpeed.Y = 15.0f;
        }
    }
}
