using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    class BoundEntity : Entity
    {
        protected Rectangle safeBounds;

        public BoundEntity() : base()
        {}

        public new void LoadContent() {
            base.LoadContent();

            // Calculate safe bounds based on current resolution
            Viewport viewport = Space.viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * 0.0f),
                (int)(viewport.Height * 0.0f),
                (int)(viewport.Width * (1 - 2 * 0.0f)),
                (int)(viewport.Height * (1 - 2 * 0.0f)));
        }

        public new void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            entityPosition.X = MathHelper.Clamp(entityPosition.X, safeBounds.Left, safeBounds.Right - entityTexture.Width);
        }

        public Rectangle getSafeBounds()
        {
            return safeBounds;
        }
    }
}
