using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.entities.ship;
using SpaceInvaders.gui;
using SpaceInvaders.managers;

namespace SpaceInvaders.world
{
    public class Space : Game
    {
        public SoundManager SoundManager;
        public readonly ContentManager ContentManager;
        public SpriteBatch SpriteBatch;
        public Viewport Viewport;
        public BulletManager BulletManager;
        public ScoreManager ScoreManager;
        public EnemyManager EntityManager;
        private BaseShip _ship;
        private CollisionManager _collisionManager;
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

            _gui = new SpaceGui(this, _ship);

            BulletManager = new BulletManager();

            _collisionManager = new CollisionManager(this, BulletManager, EntityManager);

            ScoreManager = new ScoreManager(_ship);

            SoundManager = new SoundManager(this);
            SoundManager.LoadContent();
            SoundManager.PlayLooped("theme");
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

            _gui.Draw(gameTime);

            // Update game elements
            _ship.Draw(gameTime);
            EntityManager.Draw(gameTime);
            BulletManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
