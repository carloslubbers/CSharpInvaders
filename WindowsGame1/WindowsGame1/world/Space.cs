using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.ship;
using SpaceInvaders.managers;

namespace SpaceInvaders.world
{
    public class Space : Game
    {
        public readonly ContentManager ContentManager;
        public SpriteBatch SpriteBatch;
        public Viewport Viewport;
        public BulletManager BulletManager;
        public ScoreManager ScoreManager;
        public EnemyManager EntityManager;
        private readonly GraphicsDeviceManager _graphics;
        private BaseShip _ship;
        private CollisionManager _collisionManager;

        public Space()
        {
            _graphics = new GraphicsDeviceManager(this);
            ContentManager = Content;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 920;
            _graphics.PreferredBackBufferWidth = 1800;
            Content.RootDirectory = "Content";
        }

        // Allows the game to perform any initialization it needs to before starting to run.
        protected override void Initialize()
        {
            base.Initialize();

            _ship.Initialize();
            EntityManager.Initialize();
        }

        // Load all the game ContentManager
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            _ship = new BaseShip(this);
            _ship.LoadContent();

            EntityManager = new EnemyManager(this, 120);
            EntityManager.LoadContent();

            BulletManager = new BulletManager();

            _collisionManager = new CollisionManager(this, BulletManager, EntityManager);

            ScoreManager = new ScoreManager(_ship);
        }

        // Unload all the game ContentManager
        protected override void UnloadContent() {}

        // Allows the game to run logic such as updating the world,
        // checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            Viewport = GraphicsDevice.Viewport;

            // Update game elements
            _ship.Update(gameTime);
            EntityManager.Update(gameTime);
            BulletManager.Update(gameTime);
            _collisionManager.Update(gameTime);
            base.Update(gameTime);
        }

        // This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            // The background is black
            GraphicsDevice.Clear(Color.Black);

            // TODO: Manage the UI somewhere else
            SpriteBatch.Begin();
            var x = _graphics.GraphicsDevice.Viewport.Width/2;
            var y = _graphics.GraphicsDevice.Viewport.Height/2;
                // Draw score
                SpriteBatch.DrawString(Content.Load<SpriteFont>("Segoe UI Mono"), "Score: " + ScoreManager.Score, new Vector2(x,y), Color.White, 0, Content.Load<SpriteFont>("Segoe UI Mono").MeasureString("Score: " + ScoreManager.Score) / 2, 1.0f, SpriteEffects.None, 0.5f);
            
                // Draw health
                var hc = (HealthComponent) _ship.Components["health"];
                SpriteBatch.DrawString(Content.Load<SpriteFont>("Segoe UI Mono"), "Health: " + hc.Health, new Vector2(x,y + 20), Color.White, 0, Content.Load<SpriteFont>("Segoe UI Mono").MeasureString("Health: " + hc.Health) / 2, 1.0f, SpriteEffects.None, 0.5f);
            SpriteBatch.End();

            // Update game elements
            _ship.Draw(gameTime);
            EntityManager.Draw(gameTime);
            BulletManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
