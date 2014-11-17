using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.ship;
using SpaceInvaders.gui;
using SpaceInvaders.managers;

namespace SpaceInvaders.world
{
    public class Space : Game
    {
        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentManager;
        public static Viewport Viewport;
        public static BulletManager BulletManager;
        public static ScoreManager ScoreManager;
        BaseShip _ship;
        EnemyManager _entityManager;
        CollisionManager _collisionManager;
        private SpaceGui _gui;

        public Space()
        {
            var graphics = new GraphicsDeviceManager(this);
            ContentManager = Content;
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 920;
            graphics.PreferredBackBufferWidth = 1800;
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

            _gui = new SpaceGui(_ship);

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

            _gui.Draw(gameTime);

            // Update game elements
            _ship.Draw(gameTime);
            _entityManager.Draw(gameTime);
            BulletManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
