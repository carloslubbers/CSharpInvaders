using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.ship;
using SpaceInvaders.world;

namespace SpaceInvaders.gui
{
    class SpaceGui : entities.@interface.IDrawable
    {
        private readonly SpriteBatch _sb;
        private readonly ContentManager _content;
        private readonly BaseShip _ship;

        public SpaceGui(BaseShip ship)
        {
            _sb = Space.SpriteBatch;
            _content = Space.ContentManager;
            _ship = ship;
        }
        public void Draw(GameTime gameTime)
        {
            var x = Space.Viewport.Width / 2;
            var y = Space.Viewport.Height / 2;

            _sb.Begin();
            // Draw score
            _sb.DrawString(_content.Load<SpriteFont>("GUIFont"), "Score: " + Space.ScoreManager.Score, new Vector2(x, y), Color.White, 0, _content.Load<SpriteFont>("GUIFont").MeasureString("Score: " + Space.ScoreManager.Score) / 2, 1.0f, SpriteEffects.None, 0.5f);

            // Draw health
            var hc = (HealthComponent)_ship.Components["health"];
            _sb.DrawString(_content.Load<SpriteFont>("GUIFont"), "Health: " + hc.Health, new Vector2(x, y + 20), Color.White, 0, _content.Load<SpriteFont>("GUIFont").MeasureString("Health: " + hc.Health) / 2, 1.0f, SpriteEffects.None, 0.5f);
            _sb.End();
        }
    }
}
