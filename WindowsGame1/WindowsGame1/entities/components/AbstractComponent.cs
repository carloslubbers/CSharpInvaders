﻿using Microsoft.Xna.Framework;
using SpaceInvaders.entities.interfaces;
using IDrawable = SpaceInvaders.entities.interfaces.IDrawable;

namespace SpaceInvaders.entities.components
{
    public abstract class AbstractComponent : IUpdatable, IDrawable, ILoadable
    {
        protected Entity BaseEntity;

        protected AbstractComponent(Entity baseEntity)
        {
            BaseEntity = baseEntity;
        }

        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
