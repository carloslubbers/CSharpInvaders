using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders;

namespace SpaceInvaders
{
    class Ship : Updatable, Drawable, Loadable
    {
        SpriteBatch spriteBatch;
        ContentManager content;

        Vector2 shipPosition = new Vector2(320.0f, 0.0f);
        Vector2 shipSpeed = new Vector2(-3.0f, 0.0f);
        Texture2D shipTexture;
        
        Rectangle safeBounds;

        const float SafeAreaPortion = 0.02f;
        protected String shipTextureName = "shipTexture";

        public Ship(SpriteBatch _spriteBatch, ContentManager _content)
        {
            spriteBatch = _spriteBatch;
            content = _content;
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(shipTexture, shipPosition, Color.White);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            shipPosition += shipSpeed;
            shipPosition.X = MathHelper.Clamp(shipPosition.X,
                safeBounds.Left, safeBounds.Right - shipTexture.Width);
        }

        public void LoadContent(Viewport _viewport)
        {
            shipTexture = content.Load<Texture2D>(shipTextureName);

            // Calculate safe bounds based on current resolution
            Viewport viewport = _viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * SafeAreaPortion),
                (int)(viewport.Height * SafeAreaPortion),
                (int)(viewport.Width * (1 - 2 * SafeAreaPortion)),
                (int)(viewport.Height * (1 - 2 * SafeAreaPortion)));

            // Start the player in the center along the bottom of the screen
            shipPosition.X = (safeBounds.Width - shipTexture.Width) / 2;
            shipPosition.Y = safeBounds.Height - shipTexture.Height;
        }
    }
}
