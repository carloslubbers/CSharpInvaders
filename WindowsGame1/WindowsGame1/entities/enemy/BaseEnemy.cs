using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.enemy
{
    public class BaseEnemy : Entity
    {
        public readonly Dictionary<String, AbstractComponent> Components;
        public bool Active = true;

        public BaseEnemy(Space space) : base(space)
        {
            Components = new Dictionary<string, AbstractComponent>();
            var positionComponent = new PositionComponent(this);
            var textureComponent = new TextureComponent(this, positionComponent);
            var offsetComponent = new OffsetComponent(this, positionComponent);
            var boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);

            Components.Add("position", positionComponent);
            Components.Add("texture",  textureComponent);
            Components.Add("offset", offsetComponent);
            Components.Add("boundary", boundaryComponent);
        }

        public void Initialize()
        {
            var pc = (PositionComponent) Components["position"];
            pc.EntitySpeed.X = 3.0f;
        }
        
        public override void LoadContent()
        {
            foreach (var ac in Components)
            {
                ac.Value.LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var ac in Components)
            {
                ac.Value.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Active) return;
            foreach (var ac in Components)
            {
                ac.Value.Draw(gameTime);
            }
        }
    }
}
