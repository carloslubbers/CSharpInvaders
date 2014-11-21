using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.components
{
    public class KeyboardInputComponent : AbstractInputComponent
    {
        const Keys Fire = Keys.Space;
        const Keys Left = Keys.Left;
        const Keys Right = Keys.Right;

        public KeyboardInputComponent(Entity _base, PositionComponent position, FiringComponent firing) : base(_base, position, firing) { }

        public override void Update(GameTime gameTime)
        {
            var ks = Keyboard.GetState(PlayerIndex.One);

            // Exit Game
            if (ks.IsKeyDown(Keys.Escape))
            {
                BaseEntity.Space.Exit();
            }

            // Reset enemies
            if (ks.IsKeyDown(Keys.R))
            {
                BaseEntity.Space.EntityManager.ResetEnemies();
            }

            // Fire
            if (ks.IsKeyDown(Fire))
            {
                Firing.Fire();
            }

            // Movement
            if (ks.IsKeyDown(Left) && ks.IsKeyDown(Right))
            {
                Moving = false;
            }
            else if (ks.IsKeyDown(Left))
            {
                Position.EntitySpeed.X = -1.0f*MovementSpeed;
                Moving = true;
            }
            else if (ks.IsKeyDown(Right))
            {
                Position.EntitySpeed.X = MovementSpeed;
                Moving = true;
            }
            else if (ks.IsKeyUp(Left) || ks.IsKeyUp(Right))
            {
                Moving = false;
            }

            // Stop moving if no keys are pressed
            if (!Moving) Position.EntitySpeed.X = 0.0f;
        }
    }
}