using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.ammo;
using SpaceInvaders.entities;

namespace SpaceInvaders
{
    class Ship : BoundEntity
    {
        bool moving = false;
        protected float movementSpeed = 3.0f;
        public Ship() : base()
        {
            entityTextureName = "shipTexture";

            // TODO: Ammo needs to be designed differently
        }

        public new void LoadContent()
        {
            base.LoadContent();
            // Start the player in the center along the bottom of the screen
            entityPosition.X = (safeBounds.Width - entityTexture.Width) / 2;
            entityPosition.Y = safeBounds.Height - entityTexture.Height;

        }

        public new void Update(GameTime gameTime)
        {
            // Check if movement key is pressed
            // TODO: Improve this, move firing to behaviours
            KeyboardState ks = Keyboard.GetState(PlayerIndex.One);
            if (ks.IsKeyDown(Keys.Space))
            {
                Space.bulletManager.createPlayerBullet(new Ammo(), entityPosition);
                
            }
            if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Right))
            {
                moving = false;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                entitySpeed.X = -1.0f * movementSpeed;
                moving = true;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                entitySpeed.X = movementSpeed;
                moving = true;
            }
            else if (ks.IsKeyUp(Keys.Left))
            {
                moving = false;
            }
            else if (ks.IsKeyUp(Keys.Right))
            {
                moving = false;
            }

            // Stop moving if no keys are pressed
            if (!moving) entitySpeed.X = 0.0f;

            // Update the rest
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
