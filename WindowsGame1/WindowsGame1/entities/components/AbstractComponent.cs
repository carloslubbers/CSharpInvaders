using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;
using IDrawable = SpaceInvaders.entities.interfaces.IDrawable;

namespace SpaceInvaders.entities.components
{
    public abstract class AbstractComponent : IUpdatable, IDrawable, ILoadable
    {
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
