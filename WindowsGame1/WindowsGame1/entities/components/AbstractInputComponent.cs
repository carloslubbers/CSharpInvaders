using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.components
{
    public abstract class AbstractInputComponent : AbstractComponent
    {
        protected readonly FiringComponent Firing;
        protected readonly PositionComponent Position;
        public float MovementSpeed = 5.0f;

        protected readonly Entity BaseEntity;
        protected bool Moving;

        protected AbstractInputComponent(Entity _base, PositionComponent position, FiringComponent firing)
        {
            BaseEntity = _base;
            Position = position;
            Firing = firing;
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public abstract override void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
