using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ship
{
    public class BaseShip : IEntity
    {
        public readonly Dictionary<String, AbstractComponent> Components;

        public BaseShip()
        {
            Components = new Dictionary<string, AbstractComponent>();
            var positionComponent = new PositionComponent(this);
            var textureComponent = new TextureComponent(this, positionComponent);
            var offsetComponent = new OffsetComponent(this, positionComponent);
            var boundaryComponent = new BoundaryComponent(this, positionComponent, textureComponent);
            var firingComponent = new FiringComponent(this, positionComponent);
            var inputComponent = new KeyboardInputComponent(this, positionComponent, firingComponent);
            var healthComponent = new HealthComponent(); // 100 Health

            Components.Add("position", positionComponent);
            Components.Add("texture", textureComponent);
            Components.Add("offset", offsetComponent);
            Components.Add("boundary", boundaryComponent);
            Components.Add("firing", firingComponent);
            Components.Add("input", inputComponent);
            Components.Add("health", healthComponent);
        }

        public void Initialize()
        {
            var tc = (TextureComponent) Components["texture"];
            tc.SetTexture("shipTexture");
        }
        
        public void LoadContent()
        {
            foreach(var kv in Components) {
                kv.Value.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            var pc = (PositionComponent) Components["position"];
            var tc = (TextureComponent)Components["texture"];
            pc.EntityPosition.Y = Space.Viewport.Height-tc.Texture.Height;
            foreach (var kv in Components)
            {
                kv.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var kv in Components)
            {
                kv.Value.Draw(gameTime);
            }
        }
    }
}
