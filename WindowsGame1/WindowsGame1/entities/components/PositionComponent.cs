using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;

namespace SpaceInvaders.entities.components
{
    public class PositionComponent : AbstractComponent
    {
        private readonly IEntity _base;
        public Vector2 EntityPosition = new Vector2(0.0f, 0.0f);
        public Vector2 EntitySpeed = new Vector2(0.0f, 0.0f);

        public PositionComponent(IEntity _base)
        {
            this._base = _base;
        }

        public override void LoadContent() { }

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime)
        {
            EntityPosition += EntitySpeed;
        }
    }
}
