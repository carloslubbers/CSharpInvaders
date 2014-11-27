using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class TextureComponent : AbstractComponent
    {
        private string _textureName;

        public Texture2D Texture;
        public Rectangle Bounds;

        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _contentManager;

        public TextureComponent(Entity baseEntity) : base(baseEntity)
        {
            _spriteBatch = baseEntity.Space.SpriteBatch;
            _contentManager = baseEntity.Space.ContentManager;
            _textureName = "default";
        }

        public override void LoadContent()
        {
            Texture = _contentManager.Load<Texture2D>(_textureName);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            _spriteBatch.Draw(Texture, BaseEntity.GetComponent<PositionComponent>().EntityPosition, Color.White);
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Bounds = new Rectangle((int)(BaseEntity.GetComponent<PositionComponent>().EntityPosition.X - (Texture.Width * 0.5)), (int)(BaseEntity.GetComponent<PositionComponent>().EntityPosition.Y - Texture.Height * 0.5), Texture.Width, Texture.Height);
        }

        public void SetTexture(String name)
        {
            _textureName = name;
            Texture = _contentManager.Load<Texture2D>(_textureName);
        }
    }
}
