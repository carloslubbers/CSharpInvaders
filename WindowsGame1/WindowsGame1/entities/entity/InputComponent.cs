using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public class InputComponent : Component
    {
        private bool moving = false;
        public float movementSpeed = 5.0f;

        Entity baseEntity;
        PositionComponent pos;
        FiringComponent fire;

        public InputComponent(Entity _base, PositionComponent _pos, FiringComponent _fire)
        {
            baseEntity = _base;
            pos = _pos;
            fire = _fire;
        }
        public override void LoadContent()
        {
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState(PlayerIndex.One);
            if (ks.IsKeyDown(Keys.Space))
            {
                fire.Fire();
            }
            if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Right))
            {
                moving = false;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                pos.entitySpeed.X = -1.0f * movementSpeed;
                moving = true;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                pos.entitySpeed.X = movementSpeed;
                moving = true;
            }
            else if (ks.IsKeyUp(Keys.Left))
            {
                moving = false;
            }
            else if (ks.IsKeyUp(Keys.Right))
            {
                moving = false;
            }

            // Stop moving if no keys are pressed
            if (!moving) pos.entitySpeed.X = 0.0f;
        }
    }
}
