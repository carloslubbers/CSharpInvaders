using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class BoundaryComponent : AbstractComponent
    {
        readonly TextureComponent _tex;

        Rectangle _safeBounds;

        public BoundaryComponent(Entity baseEntity) : base(baseEntity)
        {
            BaseEntity = baseEntity;
            _tex = BaseEntity.GetComponent<TextureComponent>();
        }
        public override void LoadContent()
        {
        }

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime) {
            var viewport = BaseEntity.Space.Viewport;
            _safeBounds = new Rectangle(
                (int)(viewport.Width * 0.0f),
                (int)(viewport.Height * 0.0f),
                (int)(viewport.Width * (1 - 2 * 0.0f)),
                (int)(viewport.Height * (1 - 2 * 0.0f)));

            BaseEntity.GetComponent<PositionComponent>().EntityPosition.X = MathHelper.Clamp(BaseEntity.GetComponent<PositionComponent>().EntityPosition.X, _safeBounds.Left, _safeBounds.Right - _tex.Texture.Width);
        }

        public Rectangle GetSafeBounds()
        {
            return _safeBounds;
        }
    }
}
