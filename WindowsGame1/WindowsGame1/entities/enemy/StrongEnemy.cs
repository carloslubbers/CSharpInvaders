using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class StrongEnemy : BaseEnemy
    {
        public StrongEnemy() : base()
        {
            entityTextureName = "enemy2Texture";
        }
    }
}
