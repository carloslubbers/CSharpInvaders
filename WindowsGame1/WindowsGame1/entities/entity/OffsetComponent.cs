using Microsoft.Xna.Framework;

namespace SpaceInvaders.entities.entity
{
    public class OffsetComponent : AbstractComponent
    {
        private readonly IEntity _baseEntity;
        readonly PositionComponent _pos;
        
        public Vector2 EntityOffset;

        public OffsetComponent(IEntity baseEntity, PositionComponent pos)
        {
            _baseEntity = baseEntity;
            _pos = pos;
        }

        public override void LoadContent() {}

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime) { }

        public void SetOffset(float x, float y)
        {
            EntityOffset.X = x;
            EntityOffset.Y = y;
            _pos.EntityPosition += EntityOffset;
        }
    }
}
