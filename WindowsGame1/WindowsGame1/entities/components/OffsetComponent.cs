using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class OffsetComponent : AbstractComponent
    {
        private readonly Entity _baseEntity;
        readonly PositionComponent _pos;

        private Vector2 _entityOffset;

        public OffsetComponent(Entity baseEntity, PositionComponent pos)
        {
            _baseEntity = baseEntity;
            _pos = pos;
        }

        public override void LoadContent() {}

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime) { }

        public void SetOffset(float x, float y)
        {
            _entityOffset.X = x;
            _entityOffset.Y = y;
            _pos.EntityPosition += _entityOffset;
        }
    }
}
