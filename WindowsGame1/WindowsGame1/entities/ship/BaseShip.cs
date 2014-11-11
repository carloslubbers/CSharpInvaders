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
    public class BaseShip : Entity
    {
        public Dictionary<String, AbstractComponent> components;

        public BaseShip()
        {
            components = new Dictionary<string, AbstractComponent>();
            PositionComponent positionComponent = new PositionComponent(this);
            TextureComponent textureComponent = new TextureComponent(this, positionComponent);
            OffsetComponent offsetComponent = new OffsetComponent(this, positionComponent);
            BoundaryComponent boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);
            FiringComponent firingComponent = new FiringComponent(this, positionComponent);
            InputComponent inputComponent = new InputComponent(this, positionComponent, firingComponent);

            components.Add("position", positionComponent);
            components.Add("texture", textureComponent);
            components.Add("offset", offsetComponent);
            components.Add("boundary", boundaryComponent);
            components.Add("firing", firingComponent);
            components.Add("input", inputComponent);
        }

        public void Initialize()
        {
            TextureComponent tc = (TextureComponent) components["texture"];
            tc.setTexture("shipTexture");
        }
        
        public void LoadContent()
        {
            foreach(KeyValuePair<string, AbstractComponent> kv in components) {
                kv.Value.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            PositionComponent pc = (PositionComponent) components["position"];
            TextureComponent tc = (TextureComponent)components["texture"];
            pc.entityPosition.Y = Space.viewport.Height-tc.texture.Height;
            foreach (KeyValuePair<string, AbstractComponent> kv in components)
            {
                kv.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (KeyValuePair<string, AbstractComponent> kv in components)
            {
                kv.Value.Draw(gameTime);
            }
        }
    }
}
