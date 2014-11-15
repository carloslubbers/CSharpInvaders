using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.entities.components
{
    public class KeyboardInputComponent : AbstractInputComponent
    {
        public KeyboardInputComponent(IEntity _base, PositionComponent position, FiringComponent firing) : base(_base, position, firing) { }

        public override void Update(GameTime gameTime)
        {
            var ks = Keyboard.GetState(PlayerIndex.One);

            const Keys fire = Keys.Space;
            const Keys left = Keys.Left;
            const Keys right = Keys.Right;

            if (ks.IsKeyDown(fire))
            {
                Firing.Fire();
            }
            if (ks.IsKeyDown(left) && ks.IsKeyDown(right))
            {
                Moving = false;
            }
            else if (ks.IsKeyDown(left))
            {
                Position.EntitySpeed.X = -1.0f*MovementSpeed;
                Moving = true;
            }
            else if (ks.IsKeyDown(right))
            {
                Position.EntitySpeed.X = MovementSpeed;
                Moving = true;
            }
            else if (ks.IsKeyUp(left))
            {
                Moving = false;
            }
            else if (ks.IsKeyUp(right))
            {
                Moving = false;
            }

            // Stop moving if no keys are pressed
            if (!Moving) Position.EntitySpeed.X = 0.0f;
        }
    }
}