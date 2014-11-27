using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    class EnemyAmmo : AbstractAmmo
    {
        public EnemyAmmo(Space space) : base(space)
        {
            GetComponent<TextureComponent>().SetTexture("enemy1Texture");
            GetComponent<PositionComponent>().EntitySpeed.Y = 15.0f;
        }
    }
}
