using Microsoft.Xna.Framework;
using SpaceInvaders.entities.entity;

namespace SpaceInvaders.entities.ammo
{
    public class Ammo : IEntity
    {
        public PositionComponent PositionComponent;
        public TextureComponent TextureComponent;

        public bool Active = false;
        public Ammo()
        {
            PositionComponent = new PositionComponent(this);
            TextureComponent = new TextureComponent(this, PositionComponent);

            TextureComponent.SetTexture("ammoTexture");
            PositionComponent.EntitySpeed.Y = -15.0f;
        }

        public void Fire(Vector2 p) {
            PositionComponent.EntityPosition = p;
            PositionComponent.EntityPosition.X += 27.5f;
            PositionComponent.EntityPosition.Y -= 30.0f;
            Active = true;
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
