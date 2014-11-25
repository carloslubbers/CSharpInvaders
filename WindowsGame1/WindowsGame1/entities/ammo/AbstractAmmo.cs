using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    public abstract class AbstractAmmo : Entity
    {
        public readonly Dictionary<String, AbstractComponent> Components;

        public bool Active;

        protected AbstractAmmo(Space space) : base(space)
        {
            Components = new Dictionary<string, AbstractComponent>();

            var positionComponent = new PositionComponent(this);
            var textureComponent = new TextureComponent(this, positionComponent);

            Components.Add("position", positionComponent);
            Components.Add("texture", textureComponent);
        }

        public void Fire(Vector2 p)
        {
            // Set bullet to player position and activate it
            ((PositionComponent)Components["position"]).EntityPosition = p;
            ((PositionComponent)Components["position"]).EntityPosition.X += 27.5f;
            ((PositionComponent)Components["position"]).EntityPosition.Y -= 30.0f;

            Active = true;

            // Play shooting sound
            Space.SoundManager.Play("shoot", 0.01f);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Active) return;
            foreach (var abstractComponent in Components)
            {
                abstractComponent.Value.Update(gameTime);
            }
        }

        public override void LoadContent()
        {
            foreach (var abstractComponent in Components)
            {
                abstractComponent.Value.LoadContent();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Active) return;
            foreach (var abstractComponent in Components)
            {
                abstractComponent.Value.Draw(gameTime);
            }
        }
    }
}