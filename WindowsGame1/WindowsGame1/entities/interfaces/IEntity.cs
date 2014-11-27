using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SpaceInvaders.entities.components;
using SpaceInvaders.world;

namespace SpaceInvaders.entities.interfaces
{
    public abstract class Entity : IUpdatable, ILoadable, IDrawable
    {
        public readonly Space Space;
        protected readonly List<AbstractComponent> Components;

        protected Entity(Space space)
        {
            Space = space;
            Components = new List<AbstractComponent>();
            AddComponent<PositionComponent>();
        }

        protected void AddComponent<T>()
            where T : AbstractComponent
        {
            Components.Add((T) Activator.CreateInstance(typeof (T), this));
        }

        public T GetComponent<T>()
            where T : AbstractComponent
        {
            return (T) Components.Find(c => c.GetType() == typeof (T));
        }
       

        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime);
    }
}
