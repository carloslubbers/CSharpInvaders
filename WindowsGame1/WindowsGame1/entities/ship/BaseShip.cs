using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.ship
{
    public class BaseShip : Entity
    {
        public float MovementSpeed = 5.0f;

        public BaseShip(Space space) : base(space)
        {
            AddComponent<TextureComponent>();
            AddComponent<OffsetComponent>();
            AddComponent<BoundaryComponent>();
            AddComponent<FiringComponent>();
            AddComponent<KeyboardInputComponent>();
            AddComponent<HealthComponent>();
        }

        public void Initialize()
        {
            var tc = GetComponent<TextureComponent>();
            tc.SetTexture("shipTexture");
        }
        
        public override void LoadContent()
        {
            foreach(var c in Components) {
                c.LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            var tc = GetComponent<TextureComponent>();
            GetComponent<PositionComponent>().EntityPosition.Y = Space.Viewport.Height - tc.Texture.Height;

            foreach (var c in Components)
            {
                c.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var c in Components)
            {
                c.Draw(gameTime);
            }
        }
    }
}
