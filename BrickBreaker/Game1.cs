using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BrickBreaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D image;
        float imageX;
        float imageY;
        List<Brick> bricks;

        Texture2D paddleImg;
        Paddle paddle;
        KeyboardState state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            image = Content.Load<Texture2D>("rect");
            imageX = image.Width * 0.05f;
            //imageY = image.Height * 0.5f;
            bricks = new List<Brick>();
            //bricks.Add(new Brick(image, Vector2.Zero, Color.White));
            generateBricks();

            paddleImg = Content.Load<Texture2D>("paddle");
            paddle = new Paddle(paddleImg, new Vector2(0, GraphicsDevice.Viewport.Height - (paddleImg.Height * 0.2f)), Color.White)
            {
                Scale = new Vector2(0.2f)
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            state = Keyboard.GetState();
            paddle.Update(state, GraphicsDevice.Viewport.Width);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            drawBricks();
            paddle.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void generateBricks()
        {
            //for(float i = 0; i < GraphicsDevice.Viewport.Height; i+= imageX + 10)
            //{
            //    for(float j = 0; j < GraphicsDevice.Viewport.Width; j += imageY + 5)
            //    {
            //        Vector2 position = new Vector2(i, j);
            //        Color tint = Color.White;
            //        bricks.Add(new Brick(image, position, tint));
            //    }
            //}

            for (int i = 2; i < GraphicsDevice.Viewport.Width; i += (int)imageX + 4)
            {
                if (i < GraphicsDevice.Viewport.Width - imageX)
                {
                    Vector2 position = new Vector2(i, 10);
                    Color tint = Color.White;
                    bricks.Add(new Brick(image, position, tint));
                }
            }
        }

        public void drawBricks()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Scale = new Vector2(0.05f);
                bricks[i].Draw(spriteBatch);

            }
        }
    }
}
