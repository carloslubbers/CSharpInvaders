using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceInvaders.world;
using SpaceInvaders.managers;

namespace SpaceInvaders
{
    public class Space : Microsoft.Xna.Framework.Game
    {
        public static  GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static ContentManager content;
        public static Viewport viewport;
        public static BulletManager bulletManager;
        public static ScoreManager scoreManager;
        BaseShip ship;
        EnemyManager entityManager;
        CollisionManager collisionManager;

        public Space()
        {
            graphics = new GraphicsDeviceManager(this);
            content = Content;
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 920;
            graphics.PreferredBackBufferWidth = 1800;
            Content.RootDirectory = "Content";
        }

        // Allows the game to perform any initialization it needs to before starting to run.
        protected override void Initialize()
        {
            base.Initialize();

            ship.Initialize();
            entityManager.Initialize();
        }

        // Load all the game content
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship = new BaseShip();
            ship.LoadContent();

            entityManager = new EnemyManager(120);
            entityManager.LoadContent();

            bulletManager = new BulletManager();

            collisionManager = new CollisionManager(bulletManager, entityManager);

            scoreManager = new ScoreManager(ship);
        }

        // Unload all the game content
        protected override void UnloadContent() {}

        // Allows the game to run logic such as updating the world,
        // checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            viewport = GraphicsDevice.Viewport;
            // Allows the game to exit
            if(Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape)) 
                this.Exit();

            // Update game elements
            ship.Update(gameTime);
            entityManager.Update(gameTime);
            bulletManager.Update(gameTime);
            collisionManager.Update(gameTime);
            base.Update(gameTime);
        }

        // This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            // The background is black
            GraphicsDevice.Clear(Color.Black);

            // TODO: Manage the UI somewhere else
            spriteBatch.Begin();
            spriteBatch.DrawString(Content.Load<SpriteFont>("Segoe UI Mono"), "Score: " + scoreManager.score, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
        graphics.GraphicsDevice.Viewport.Height / 2), Color.White, 0, Content.Load<SpriteFont>("Segoe UI Mono").MeasureString("Score: " + scoreManager.score) / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();

            // Update game elements
            ship.Draw(gameTime);
            entityManager.Draw(gameTime);
            bulletManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
