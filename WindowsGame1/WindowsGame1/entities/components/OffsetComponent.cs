using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class OffsetComponent : AbstractComponent
    {
        private Vector2 _entityOffset;

        public OffsetComponent(Entity baseEntity) : base(baseEntity)
        {
            BaseEntity = baseEntity;
        }

        public override void LoadContent() {}

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime) { }

        public void SetOffset(float x, float y)
        {
            _entityOffset.X = x;
            _entityOffset.Y = y;
            BaseEntity.GetComponent<PositionComponent>().EntityPosition += _entityOffset;
        }
    }
}
