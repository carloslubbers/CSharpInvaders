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
        public Dictionary<String, AbstractComponent> components;
        public bool active = true;

        public BaseEnemy()
        {
            components = new Dictionary<string, AbstractComponent>();
            PositionComponent positionComponent = new PositionComponent(this);
            TextureComponent textureComponent = new TextureComponent(this, positionComponent);
            OffsetComponent offsetComponent = new OffsetComponent(this, positionComponent);
            BoundaryComponent boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);

            components.Add("position", positionComponent);
            components.Add("texture",  textureComponent);
            components.Add("offset", offsetComponent);
            components.Add("boundary", boundaryComponent);
        }

        public void Initialize()
        {
            PositionComponent pc = (PositionComponent) components["position"];
            pc.entitySpeed.X = 3.0f;
        }
        
        public void LoadContent()
        {
            foreach (KeyValuePair<string, AbstractComponent> ac in components)
            {
                ac.Value.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, AbstractComponent> ac in components)
            {
                ac.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (active)
            {
                foreach (KeyValuePair<string, AbstractComponent> ac in components)
                {
                    ac.Value.Draw(gameTime);
                }
            }
        }
    }
}
