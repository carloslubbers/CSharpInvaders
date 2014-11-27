using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.enemy
{
    public class BaseEnemy : Entity
    {
        public bool Active = true;

        public BaseEnemy(Space space) : base(space)
        {
            AddComponent<TextureComponent>();
            AddComponent<OffsetComponent>();
            AddComponent<BoundaryComponent>();
        }

        public void Initialize()
        {
            GetComponent<PositionComponent>().EntitySpeed.X = 3.0f;
        }
        
        public override void LoadContent()
        {
            foreach (var c in Components)
            {
                c.LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var c in Components)
            {
                c.Update(gameTime);
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
