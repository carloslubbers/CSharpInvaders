using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities;
using SpaceInvaders.entities.ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class BaseEnemy : BoundEntity
    {
        protected Vector2 entityOffset = new Vector2(0.0f, 0.0f);

        public BaseEnemy() : base()
        {
            entityTextureName = "enemy1Texture";
            entitySpeed.X = 2.0f;
            
        }

        public void LoadContent(Viewport _viewport)
        {
            base.LoadContent();
            entityPosition += entityOffset;
        }

        public void setOffset(float x, float y)
        {
            entityOffset.X = x;
            entityOffset.Y = y;
            entityPosition += entityOffset;
        }
    }
}
