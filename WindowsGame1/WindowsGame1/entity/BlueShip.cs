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
        public BlueShip(SpriteBatch _spriteBatch, ContentManager _content) : base(_spriteBatch, _content)
        {
            shipTextureName = "blueshipTexture";
        }
    }
}
