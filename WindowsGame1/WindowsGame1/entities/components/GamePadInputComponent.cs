using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.entities.components
{
    public class GamePadInputComponent : AbstractInputComponent
    {
        public GamePadInputComponent(IEntity _base, PositionComponent position, FiringComponent firing) : base(_base, position, firing)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var gp = GamePad.GetState(PlayerIndex.One);

            const Buttons fire = Buttons.A;
            const Buttons left = Buttons.DPadLeft;
            const Buttons right = Buttons.DPadRight;

            if (gp.IsButtonDown(fire))
            {
                Firing.Fire();
            }
            if (gp.IsButtonDown(left) && gp.IsButtonDown(right))
            {
                Moving = false;
            }
            else if (gp.IsButtonDown(left))
            {
                Position.EntitySpeed.X = -1.0f * MovementSpeed;
                Moving = true;
            }
            else if (gp.IsButtonDown(right))
            {
                Position.EntitySpeed.X = MovementSpeed;
                Moving = true;
            }
            else if (gp.IsButtonUp(left))
            {
                Moving = false;
            }
            else if (gp.IsButtonUp(right))
            {
                Moving = false;
            }

            // Stop moving if no keys are pressed
            if (!Moving) Position.EntitySpeed.X = 0.0f;
        }
    }
}
