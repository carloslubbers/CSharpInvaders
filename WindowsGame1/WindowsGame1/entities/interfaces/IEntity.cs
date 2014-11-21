using Microsoft.Xna.Framework;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.interfaces
{
    public abstract class Entity : IUpdatable, ILoadable, IDrawable
    {
        public readonly Space Space;

        protected Entity(Space space)
        {
            Space = space;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
    }
}
