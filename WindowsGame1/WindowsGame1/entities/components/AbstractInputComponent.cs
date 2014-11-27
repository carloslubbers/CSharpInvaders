using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public abstract class AbstractInputComponent : AbstractComponent
    {
        protected readonly FiringComponent Firing;
        protected bool Moving;

        protected AbstractInputComponent(Entity baseEntity) : base(baseEntity)
        {
            BaseEntity = baseEntity;
            Firing = baseEntity.GetComponent<FiringComponent>();
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public abstract override void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
