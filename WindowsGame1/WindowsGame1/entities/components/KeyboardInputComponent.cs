using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class KeyboardInputComponent : AbstractInputComponent
    {
        const Keys Fire = Keys.Space;
        const Keys Left = Keys.Left;
        const Keys Right = Keys.Right;

        public KeyboardInputComponent(Entity baseEntity) : base(baseEntity) { }

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
                BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = -1.0f * BaseEntity.GetComponent<PositionComponent>().MovementSpeed.X;
                Moving = true;
            }
            else if (ks.IsKeyDown(Right))
            {
                BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = BaseEntity.GetComponent<PositionComponent>().MovementSpeed.X;
                Moving = true;
            }
            else if (ks.IsKeyUp(Left) || ks.IsKeyUp(Right))
            {
                Moving = false;
            }

            // Stop moving if no keys are pressed
            if (!Moving) BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = 0.0f;
        }
    }
}