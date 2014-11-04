using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : Entity
    {
        public PositionComponent positionComponent;
        public TextureComponent textureComponent;

        public bool active;
        public Ammo()
        {
            positionComponent = new PositionComponent(this);
            textureComponent = new TextureComponent(this, positionComponent);
            textureComponent.setTexture("ammoTexture");
            positionComponent.entitySpeed.Y = -10.0f;
        }

        public void Fire(Vector2 p) {
            positionComponent.entityPosition = p;
            positionComponent.entityPosition.X += 27.5f;
            positionComponent.entityPosition.Y -= 30.0f;
            active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (active)
            {
                positionComponent.Update(gameTime);
                textureComponent.Update(gameTime);
            }
        }

        public void LoadContent()
        {
            textureComponent.LoadContent();
            positionComponent.entitySpeed.Y = -10.0f;
            active = false;
        }

        public void Draw(GameTime gameTime)
        {
            if (active)
            {
                textureComponent.Draw(gameTime);
            }
        }
    }
}
