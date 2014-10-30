using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class FastEnemy : BaseEnemy
    {
        public FastEnemy()
            : base()
        {
            entityTextureName = "enemy3Texture";
        }
    }
}
