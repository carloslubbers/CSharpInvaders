using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : Entity
    {
        public Ammo()
            : base()
        {
            entityTextureName = "ammoTexture";
            entitySpeed.Y = -10.0f;
            active = false;
            base.LoadContent();
        }

        public void Fire(Vector2 p) {
            entityPosition = p;
            entityPosition.X += 27.5f;
            entityPosition.Y -= 30.0f;
            active = true;
        }
    }
}
