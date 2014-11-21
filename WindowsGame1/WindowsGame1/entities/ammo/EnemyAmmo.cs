using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    class EnemyAmmo : Ammo
    {
        public EnemyAmmo(Space space) : base(space)
        {
            TextureComponent.SetTexture("enemy1Texture");
            PositionComponent.EntitySpeed.Y = 15.0f;
        }
    }
}
