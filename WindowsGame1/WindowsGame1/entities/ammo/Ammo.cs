using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : AbstractAmmo
    {
        
        public Ammo(Space space) : base(space)
        {
            GetComponent<TextureComponent>().SetTexture("ammoTexture");
            GetComponent<PositionComponent>().EntitySpeed.Y = -15.0f;
        }
    }
}
