using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ammo
{
    class Ammo : Entity
    {
        public Ammo(SpriteBatch _spriteBatch, ContentManager _content)
            : base(_spriteBatch, _content)
        {
            entityTextureName = "default";
            entitySpeed.Y = -4.0f;
            updating = false;
            drawing = false;
            obeysSafeBounds = false;
        }

        public void Fire(Vector2 p) {
            entityPosition = p;
            updating = true;
            drawing = true;
        }
    }
}
