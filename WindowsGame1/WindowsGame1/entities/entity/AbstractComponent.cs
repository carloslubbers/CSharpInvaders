using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.entities
{
    public abstract class AbstractComponent : Updatable, Drawable, Loadable
    {
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
