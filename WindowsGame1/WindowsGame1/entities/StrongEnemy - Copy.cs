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
        public StrongEnemy(SpriteBatch _spriteBatch, ContentManager _content) : base(_spriteBatch, _content)
        {
            entityTextureName = "enemy2Texture";
        }
    }
}
