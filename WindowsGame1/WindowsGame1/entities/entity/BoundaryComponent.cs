using Microsoft.Xna.Framework;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.entity
{
    public class BoundaryComponent : AbstractComponent
    {
        IEntity _baseEntity;
        readonly PositionComponent _pos;
        readonly TextureComponent _tex;

        Rectangle _safeBounds;

        public BoundaryComponent(IEntity baseEntity, PositionComponent pos, TextureComponent tex)
        {
            _baseEntity = baseEntity;
            _pos = pos;
            _tex = tex;
        }
        public override void LoadContent()
        {
        }

        public override void Draw(GameTime gameTime) { }

        public override void Update(GameTime gameTime) {
            var viewport = Space.Viewport;
            _safeBounds = new Rectangle(
                (int)(viewport.Width * 0.0f),
                (int)(viewport.Height * 0.0f),
                (int)(viewport.Width * (1 - 2 * 0.0f)),
                (int)(viewport.Height * (1 - 2 * 0.0f)));

            _pos.EntityPosition.X = MathHelper.Clamp(_pos.EntityPosition.X, _safeBounds.Left, _safeBounds.Right - _tex.Texture.Width);
        }

        public Rectangle GetSafeBounds()
        {
            return _safeBounds;
        }
    }
}
