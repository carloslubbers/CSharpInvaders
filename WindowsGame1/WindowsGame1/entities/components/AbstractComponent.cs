using Microsoft.Xna.Framework;
using SpaceInvaders.entities.@interface;
using IDrawable = SpaceInvaders.entities.@interface.IDrawable;

namespace SpaceInvaders.entities.components
{
    public abstract class AbstractComponent : IUpdatable, IDrawable, ILoadable
    {
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
