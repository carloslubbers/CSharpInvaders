using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.interfaces;

namespace SpaceInvaders.entities.components
{
    public class GamePadInputComponent : AbstractInputComponent
    {
        const Buttons Fire = Buttons.A;
        const Buttons Left = Buttons.DPadLeft;
        const Buttons Right = Buttons.DPadRight;

        public GamePadInputComponent(Entity baseEntity) : base(baseEntity)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var gp = GamePad.GetState(PlayerIndex.One);

            // Exit Game
            if (gp.IsButtonDown(Buttons.Y))
            {
                BaseEntity.Space.Exit();
            }

            // Reset enemies
            if (gp.IsButtonDown(Buttons.X))
            {
                BaseEntity.Space.EntityManager.ResetEnemies();
            }

            // Fire
            if (gp.IsButtonDown(Fire))
            {
                Firing.Fire();
            }

            // Movement
            if (gp.IsButtonDown(Left) && gp.IsButtonDown(Right))
            {
                Moving = false;
            }
            else if (gp.IsButtonDown(Left))
            {
                BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = -1.0f * BaseEntity.GetComponent<PositionComponent>().MovementSpeed.X;
                Moving = true;
            }
            else if (gp.IsButtonDown(Right))
            {
                BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = BaseEntity.GetComponent<PositionComponent>().MovementSpeed.X;
                Moving = true;
            }
            else if (gp.IsButtonUp(Left) || gp.IsButtonUp(Right))
            {
                Moving = false;
            }

            // Stop moving if no buttons are pressed
            if (!Moving) BaseEntity.GetComponent<PositionComponent>().EntitySpeed.X = 0.0f;
        }
    }
}
