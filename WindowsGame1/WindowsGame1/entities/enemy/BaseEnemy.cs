using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities;
using SpaceInvaders.entities.ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class BaseEnemy : Entity
    {
        public PositionComponent positionComponent;
        public TextureComponent textureComponent;
        public OffsetComponent offsetComponent;
        public BoundaryComponent boundaryComponent;

        public bool active = true;

        public BaseEnemy()
        {
            positionComponent = new PositionComponent(this);
            textureComponent = new TextureComponent(this, positionComponent);
            offsetComponent = new OffsetComponent(this, positionComponent);
            boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);
        }

        public void Initialize()
        {
            positionComponent.entitySpeed.X = 3.0f;
        }
        
        public void LoadContent()
        {
            positionComponent.LoadContent();
            textureComponent.LoadContent();
            offsetComponent.LoadContent();
            boundaryComponent.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            positionComponent.Update(gameTime);
            textureComponent.Update(gameTime);
            boundaryComponent.Update(gameTime);
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
