using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ship
{
    class ShipDecorator : Ship
    {
        ShipBase baseComponent = null;
    
        protected string m_Name = "Undefined Decorator";
        protected double m_Price = 0.0;

        protected ShipDecorator(ShipBase _baseComponent)
        {
            baseComponent = _baseComponent;
        }

        public override void LoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
