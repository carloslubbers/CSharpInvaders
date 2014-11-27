using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    class HealthComponent : AbstractComponent
    {
        public float Health = 100.0f;

        public HealthComponent(Entity baseEntity) : base(baseEntity)
        {
        }

        public override void LoadContent() {}

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {}

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {}

        public void Damage(float d)
        {
            Health -= d;
        }
    }
}
