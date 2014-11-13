using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.entities.entity
{
    public class InputComponent : AbstractComponent
    {
        private bool _moving;
        public float MovementSpeed = 5.0f;

        IEntity _baseEntity;
        readonly PositionComponent _pos;
        readonly FiringComponent _fire;

        public InputComponent(IEntity _base, PositionComponent pos, FiringComponent fire)
        {
            _baseEntity = _base;
            _pos = pos;
            _fire = fire;
        }
        public override void LoadContent()
        {
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var ks = Keyboard.GetState(PlayerIndex.One);
            if (ks.IsKeyDown(Keys.Space))
            {
                _fire.Fire();
            }
            if (ks.IsKeyDown(Keys.Left) && ks.IsKeyDown(Keys.Right))
            {
                _moving = false;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                _pos.EntitySpeed.X = -1.0f * MovementSpeed;
                _moving = true;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                _pos.EntitySpeed.X = MovementSpeed;
                _moving = true;
            }
            else if (ks.IsKeyUp(Keys.Left))
            {
                _moving = false;
            }
            else if (ks.IsKeyUp(Keys.Right))
            {
                _moving = false;
            }

            // Stop moving if no keys are pressed
            if (!_moving) _pos.EntitySpeed.X = 0.0f;
        }
    }
}
