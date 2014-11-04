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
    class BaseShip : Entity
    {
        public PositionComponent positionComponent;
        public TextureComponent textureComponent;
        public InputComponent inputComponent;
        public FiringComponent firingComponent;

        public BaseShip()
        {
            positionComponent = new PositionComponent(this);
            textureComponent = new TextureComponent(this, positionComponent);
            firingComponent = new FiringComponent(this, positionComponent);
            inputComponent = new InputComponent(this, positionComponent, firingComponent);
        }

        public void Initialize()
        {
            textureComponent.setTexture("shipTexture");
            positionComponent.entityPosition.Y = 800.0f;
        }
        
        public void LoadContent()
        {
            positionComponent.LoadContent();
            textureComponent.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            positionComponent.Update(gameTime);
            textureComponent.Update(gameTime);
            inputComponent.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            textureComponent.Draw(gameTime);
        }
    }
}
