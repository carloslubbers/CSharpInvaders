using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class PositionComponent : AbstractComponent
    {
        public Vector2 EntityPosition = new Vector2(0.0f, 0.0f);
        public Vector2 EntitySpeed = new Vector2(0.0f, 0.0f);
        public Vector2 MovementSpeed = new Vector2(5.0f, 0.0f);

        public PositionComponent(Entity baseEntity) : base(baseEntity)
        {
            BaseEntity = baseEntity;
        }

        public override void LoadContent() { }

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime)
        {
            EntityPosition += EntitySpeed;
        }
    }
}
