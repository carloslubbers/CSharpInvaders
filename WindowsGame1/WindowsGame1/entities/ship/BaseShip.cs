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
        public BoundaryComponent boundaryComponent;

        public BaseShip()
        {
            positionComponent = new PositionComponent(this);
            textureComponent = new TextureComponent(this, positionComponent);
            firingComponent = new FiringComponent(this, positionComponent);
            inputComponent = new InputComponent(this, positionComponent, firingComponent);
            boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);
        }

        public void Initialize()
        {
            textureComponent.setTexture("shipTexture");
        }
        
        public void LoadContent()
        {
            positionComponent.LoadContent();
            textureComponent.LoadContent();
            boundaryComponent.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            positionComponent.entityPosition.Y = Space.viewport.Height-textureComponent.texture.Height;
            positionComponent.Update(gameTime);
            textureComponent.Update(gameTime);
            inputComponent.Update(gameTime);
            boundaryComponent.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            textureComponent.Draw(gameTime);
        }
    }
}
