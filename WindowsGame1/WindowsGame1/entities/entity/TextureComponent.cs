using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.entity
{
    public class TextureComponent : AbstractComponent
    {
        private string _textureName;

        public Texture2D Texture;
        public Rectangle Bounds;

        IEntity _baseEntity;
        readonly PositionComponent _pos;

        public TextureComponent(IEntity _base, PositionComponent pos)
        {
            _baseEntity = _base;
            _pos = pos;
            _textureName = "default";
        }

        public override void LoadContent()
        {
            Texture = Space.ContentManager.Load<Texture2D>(_textureName);
        }

        public override void Draw(GameTime gameTime)
        {
            Space.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            Space.SpriteBatch.Draw(Texture, _pos.EntityPosition, Color.White);
            Space.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Bounds = new Rectangle((int)(_pos.EntityPosition.X - Texture.Width / 2), (int)(_pos.EntityPosition.Y - Texture.Height / 2), Texture.Width, Texture.Height);
        }

        public void SetTexture(String name)
        {
            _textureName = name;
            Texture = Space.ContentManager.Load<Texture2D>(_textureName);
        }
    }
}
