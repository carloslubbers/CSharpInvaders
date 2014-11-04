using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class PositionComponent : Component
    {
        public Vector2 entityPosition = new Vector2(0.0f, 0.0f);
        public Vector2 entitySpeed = new Vector2(0.0f, 0.0f);
        private Entity baseEntity;

        public PositionComponent(Entity _base)
        {
            baseEntity = _base;
        }

        public override void LoadContent()
        {

        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            entityPosition += entitySpeed;
        }
    }
}
