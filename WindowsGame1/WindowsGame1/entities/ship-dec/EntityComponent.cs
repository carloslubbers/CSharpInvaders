using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ship_dec
{
    public class EntityComponent : Component
    {
        public Vector2 entityPosition = new Vector2(0.0f, 0.0f);
        public Vector2 entitySpeed = new Vector2(0.0f, 0.0f);
        public Texture2D entityTexture;
        public String entityTextureName = "default";
        public Rectangle bounds;

        protected bool active = true;

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            entityTexture = Space.content.Load<Texture2D>(entityTextureName);
        }

        public override void Update(GameTime gameTime)
        {
            entityPosition += entitySpeed;

            if (active)
            {
                bounds = new Rectangle((int)(entityPosition.X - entityTexture.Width / 2), (int)(entityPosition.Y - entityTexture.Height / 2), entityTexture.Width, entityTexture.Height);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (active)
            {
                Space.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                Space.spriteBatch.Draw(entityTexture, entityPosition, Color.White);
                Space.spriteBatch.End();
            }
        }
    }
}
