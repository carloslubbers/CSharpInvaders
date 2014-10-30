using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class BlueShip : Ship
    {
        public BlueShip() : base()
        {
            entityTextureName = "blueshipTexture";
            movementSpeed = 12.0f;
        }
    }
}
