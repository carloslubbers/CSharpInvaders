namespace SpaceInvaders.entities.components
{
    public abstract class AbstractInputComponent : AbstractComponent
    {
        protected readonly FiringComponent Firing;
        protected readonly PositionComponent Position;
        public float MovementSpeed = 5.0f;

        private IEntity _baseEntity;
        protected bool Moving;

        protected AbstractInputComponent(IEntity _base, PositionComponent position, FiringComponent firing)
        {
            _baseEntity = _base;
            Position = position;
            Firing = firing;
        }

        public override void LoadContent() { }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public abstract override void Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
