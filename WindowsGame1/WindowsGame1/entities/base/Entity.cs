using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class Entity : Updatable, Drawable, Loadable
    {

        protected Vector2 entityPosition = new Vector2(0.0f, 0.0f);
        protected Vector2 entitySpeed = new Vector2(0.0f, 0.0f);
        protected Texture2D entityTexture;
        protected String entityTextureName = "default";
        protected Rectangle bounds;

        protected bool active = true;

        public void LoadContent()
        {
            entityTexture = Space.content.Load<Texture2D>(entityTextureName);
        }

        public void Draw(GameTime gameTime)
        {
            if (active)
            {
                Space.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                Space.spriteBatch.Draw(entityTexture, entityPosition, Color.White);
                Space.spriteBatch.End();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (active)
            {
                entityPosition += entitySpeed;
                bounds = new Rectangle((int)(entityPosition.X - entityTexture.Width / 2), (int)(entityPosition.Y - entityTexture.Height / 2), entityTexture.Width, entityTexture.Height);
            }
        }

        /* Getters & Setters */

        public void setSpeed(float x, float y)
        {
            entitySpeed.X = x;
            entitySpeed.Y = y;
        }

        public Vector2 getSpeed()
        {
            return entitySpeed;
        }
        
        public Vector2 getPosition()
        {
            return entityPosition;
        }

        public Texture2D getTexture()
        {
            return entityTexture;
        }

        public Rectangle getBounds()
        {
            return bounds;
        }

        public Boolean isActive()
        {
            return active;
        }

        public void setActive(Boolean a)
        {
            active = a;
        }
    }
}
