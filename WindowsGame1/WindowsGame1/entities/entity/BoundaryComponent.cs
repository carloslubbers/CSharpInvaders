using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class BoundaryComponent : AbstractComponent
    {
        Entity baseEntity;
        PositionComponent pos;
        TextureComponent tex;

        Rectangle safeBounds;

        public BoundaryComponent(Entity _base, PositionComponent _pos, TextureComponent _tex)
        {
            baseEntity = _base;
            pos = _pos;
            tex = _tex;
        }
        public override void LoadContent()
        {
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            Viewport viewport = Space.viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * 0.0f),
                (int)(viewport.Height * 0.0f),
                (int)(viewport.Width * (1 - 2 * 0.0f)),
                (int)(viewport.Height * (1 - 2 * 0.0f)));

            pos.entityPosition.X = MathHelper.Clamp(pos.entityPosition.X, safeBounds.Left, safeBounds.Right - tex.texture.Width);
        }

        public Rectangle getSafeBounds()
        {
            return safeBounds;
        }
    }
}
