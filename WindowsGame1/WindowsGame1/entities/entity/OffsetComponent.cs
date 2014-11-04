using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class OffsetComponent : Component
    {
        Entity baseEntity;
        PositionComponent pos;
        
        public Vector2 entityOffset;

        public OffsetComponent(Entity _base, PositionComponent _pos)
        {
            baseEntity = _base;
            pos = _pos;
        }
        public override void LoadContent() {}

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) { }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) { }

        public void setOffset(float x, float y)
        {
            entityOffset.X = x;
            entityOffset.Y = y;
            pos.entityPosition += entityOffset;
        }
    }
}
