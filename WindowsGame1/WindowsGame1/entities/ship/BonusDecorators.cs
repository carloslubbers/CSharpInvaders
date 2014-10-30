using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ship
{
    class RateOfFireDecorator : ShipDecorator
    {

    }

    class SpeedDecorator : ShipDecorator
    {

    }

    class TextureDecorator : ShipDecorator
    {
        public TextureDecorator(ShipDecorator _baseComponent)
        : base(_baseComponent)
    {
        this.m_Name = "Artificial Scent";
        this.m_Price = 3.0;
    }
    }
}
