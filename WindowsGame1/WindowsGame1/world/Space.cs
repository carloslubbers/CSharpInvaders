using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.entity;
using SpaceInvaders.entities.ship;
using SpaceInvaders.managers;

namespace SpaceInvaders.world
{
    public class Space : Game
    {
        private static  GraphicsDeviceManager _graphics;
        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentManager;
        public static Viewport Viewport;
        public static BulletManager BulletManager;
        public static ScoreManager ScoreManager;
        BaseShip _ship;
        EnemyManager _entityManager;
        CollisionManager _collisionManager;

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
            _entityManager.Initialize();
        }

        // Load all the game ContentManager
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            _ship = new BaseShip();
            _ship.LoadContent();

            _entityManager = new EnemyManager(120);
            _entityManager.LoadContent();

            BulletManager = new BulletManager();

            _collisionManager = new CollisionManager(BulletManager, _entityManager);

            ScoreManager = new ScoreManager(_ship);
        }

        // Unload all the game ContentManager
        protected override void UnloadContent() {}

        // Allows the game to run logic such as updating the world,
        // checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            Viewport = GraphicsDevice.Viewport;
            // Allows the game to exit
            if(Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape)) 
                Exit();

            // Update game elements
            _ship.Update(gameTime);
            _entityManager.Update(gameTime);
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
            _entityManager.Draw(gameTime);
            BulletManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
