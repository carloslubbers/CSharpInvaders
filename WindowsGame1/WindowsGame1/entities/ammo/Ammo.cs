using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : IEntity
    {
        protected readonly PositionComponent PositionComponent;
        public readonly TextureComponent TextureComponent;

        public bool Active;
        public Ammo()
        {
            PositionComponent = new PositionComponent(this);
            TextureComponent = new TextureComponent(this, PositionComponent);

            TextureComponent.SetTexture("ammoTexture");
            PositionComponent.EntitySpeed.Y = -15.0f;
        }

        public void Fire(Vector2 p) {
            // Set bullet to player position and activate it
            PositionComponent.EntityPosition = p;
            PositionComponent.EntityPosition.X += 27.5f;
            PositionComponent.EntityPosition.Y -= 30.0f;
            Active = true;

            // Play shooting sound
            Space.SoundManager.Play("shoot", 0.01f);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active) return;
            PositionComponent.Update(gameTime);
            TextureComponent.Update(gameTime);
        }

        public void LoadContent()
        {
            TextureComponent.LoadContent();
        }

        public void Draw(GameTime gameTime)
        {
            if (Active)
            {
                TextureComponent.Draw(gameTime);
            }
        }
    }
}
