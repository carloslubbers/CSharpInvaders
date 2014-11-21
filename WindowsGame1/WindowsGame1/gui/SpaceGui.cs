using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.ship;
using SpaceInvaders.world;

namespace SpaceInvaders.gui
{
    public class SpaceGui : entities.interfaces.IDrawable
    {
        private readonly SpriteBatch _sb;
        private readonly ContentManager _content;
        private readonly Space _space;
        private readonly BaseShip _ship;

        public SpaceGui(Space space, BaseShip ship)
        {
            _sb = space.SpriteBatch;
            _content = space.ContentManager;
            _space = space;
            _ship = ship;
        }
        public void Draw(GameTime gameTime)
        {
            var x = _space.Viewport.Width / 2;
            var y = _space.Viewport.Height / 2;

            _sb.Begin();
            // Draw score
            _sb.DrawString(_content.Load<SpriteFont>("GUIFont"), "Score: " + _space.ScoreManager.Score, new Vector2(x, y), Color.White, 0, _content.Load<SpriteFont>("GUIFont").MeasureString("Score: " +  _space.ScoreManager.Score) / 2, 1.0f, SpriteEffects.None, 0.5f);

            // Draw health
            var hc = (HealthComponent)_ship.Components["health"];
            _sb.DrawString(_content.Load<SpriteFont>("GUIFont"), "Health: " + hc.Health, new Vector2(x, y + 20), Color.White, 0, _content.Load<SpriteFont>("GUIFont").MeasureString("Health: " + hc.Health) / 2, 1.0f, SpriteEffects.None, 0.5f);
            _sb.End();
        }
    }
}
