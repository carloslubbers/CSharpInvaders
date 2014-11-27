using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    public abstract class AbstractAmmo : Entity
    {
        public bool Active;

        protected AbstractAmmo(Space space) : base(space)
        {
            AddComponent<TextureComponent>();
        }

        public void Fire(Vector2 p)
        {
            // Set bullet to player position and activate it
            GetComponent<PositionComponent>().EntityPosition = p;
            GetComponent<PositionComponent>().EntityPosition.X += 27.5f;
            GetComponent<PositionComponent>().EntityPosition.Y -= 30.0f;

            Active = true;

            // Play shooting sound
            Space.SoundManager.Play("shoot", 0.01f);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Active) return;
            foreach (var c in Components)
            {
                c.Update(gameTime);
            }
        }

        public override void LoadContent()
        {
            foreach (var c in Components)
            {
                c.LoadContent();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Active) return;
            foreach (var c in Components)
            {
                c.Draw(gameTime);
            }
        }
    }
}