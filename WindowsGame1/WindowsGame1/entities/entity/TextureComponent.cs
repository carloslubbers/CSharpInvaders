using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class TextureComponent : AbstractComponent
    {
        private string textureName;

        public Texture2D texture;
        public Rectangle bounds;

        Entity baseEntity;
        PositionComponent pos;

        public TextureComponent(Entity _base, PositionComponent _pos)
        {
            baseEntity = _base;
            pos = _pos;
            textureName = "default";
        }

        public override void LoadContent()
        {
            texture = Space.content.Load<Texture2D>(textureName);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Space.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            Space.spriteBatch.Draw(texture, pos.entityPosition, Color.White);
            Space.spriteBatch.End();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            bounds = new Rectangle((int)(pos.entityPosition.X - texture.Width / 2), (int)(pos.entityPosition.Y - texture.Height / 2), texture.Width, texture.Height);
        }

        public void setTexture(String _name)
        {
            textureName = _name;
            texture = Space.content.Load<Texture2D>(textureName);
        }
    }
}
