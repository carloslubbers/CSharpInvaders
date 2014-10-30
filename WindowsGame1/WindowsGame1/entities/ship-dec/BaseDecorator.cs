using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ship_dec
{
    // Decorator
    abstract class BaseDecorator : EntityComponent
    {
        protected EntityComponent component;

        public void SetComponent(EntityComponent component)
        {
            this.component = component;
        }

        public override void LoadContent()
        {
            if (component != null)
            {
                component.LoadContent();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (component != null)
            {
                component.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (component != null)
            {
                component.Update(gameTime);
            }
        }
    }
}
