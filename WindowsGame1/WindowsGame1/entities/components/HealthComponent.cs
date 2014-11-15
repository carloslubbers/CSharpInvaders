﻿using SpaceInvaders.entities.components;

namespace SpaceInvaders.entities.components
{
    class HealthComponent : AbstractComponent
    {
        public float Health = 100.0f;

        public HealthComponent()
        {
            // Health uses default value (100.0f)
        }

        public HealthComponent(float health)
        {
            Health = health;
        }

        public override void LoadContent() {}

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {}

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {}

        public void Damage(float d)
        {
            Health -= d;
        }
    }
}
