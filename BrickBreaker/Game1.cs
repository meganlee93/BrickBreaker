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
        List<List<Brick>> levelBricks;
        string[] brickColor = new string[3];

        Texture2D paddleImg;
        Paddle paddle;
        KeyboardState state;

        //Ball
        Ball ball;
        Texture2D ballImg;
        bool hit;

        //Font
        SpriteFont font;
        string score;
        Vector2 fontSize;
        int playerScore;



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

            brickColor[0] = "brick";
            brickColor[1] = "gBrick";
            brickColor[2] = "yBrick";
            image = Content.Load<Texture2D>(brickColor[0]);
            imageX = image.Width * 0.2f;
            imageY = image.Height * 0.2f;
            bricks = new List<Brick>();
            levelBricks = new List<List<Brick>>();


            paddleImg = Content.Load<Texture2D>("paddle");
            paddle = new Paddle(paddleImg, new Vector2(GraphicsDevice.Viewport.Width/2 - (paddleImg.Width * 0.2f)/2, GraphicsDevice.Viewport.Height - (paddleImg.Height * 0.2f)), Color.White)
            {
                Scale = new Vector2(0.2f)
            };

            //Ball
            ballImg = Content.Load<Texture2D>("premierBall");
            ball = new Ball(ballImg,
                new Vector2(GraphicsDevice.Viewport.Width / 2 - ((ballImg.Width / 2) * 0.05f), GraphicsDevice.Viewport.Height / 2 - ((ballImg.Height / 2) * 0.05f)),
                Color.White)
            {
                Scale = new Vector2(0.05f)
            };

            playerScore = 0;
            score = "Score: " + playerScore;
            font = Content.Load<SpriteFont>("SpriteFont1");
            fontSize = font.MeasureString(score);

            hit = false;

            generateBricks();
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
            fontSize = font.MeasureString(score);

            if (!ball.NewBall)
            {
                paddle.Update(state, GraphicsDevice.Viewport.Width);
                ball.Update(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, paddle);
                //for(int i = 0; i < levelBricks.Count; i++)
                //{
                //    for(int j = 0; j < levelBricks[i].Count; j++)
                //    {
                //        ball.Update(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, paddle, levelBricks[i][j]);
                //    }
                //}

                //fixing getting rid of bricks
                for(int i = 0; i < levelBricks.Count; i++)
                {
                    for(int j = 0; j < levelBricks[i].Count; j++)
                    {
                        if(ball.CheckCollision(levelBricks[i][j]))
                        {
                            hit = true;
                            levelBricks[i].Remove(levelBricks[i][j]);
                            break;
                        }
                    }

                    if(hit)
                    {
                        hit = false;
                        break;
                    }
                }
            }
            else if(ball.NewBall)
            {
                if (state.IsKeyDown(Keys.Space))
                {
                    ball.NewBall = false;
                }
            }
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

            spriteBatch.DrawString(font, score, Vector2.Zero, Color.White);
            drawBricks();
            paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void generateBricks()
        {
            float heightLevel = fontSize.Y + 10;
            Color tint = Color.White;
            for (int level = 0; level < 3; level++)
            {
                image = Content.Load<Texture2D>(brickColor[level]);
                for (int i = 2; i < GraphicsDevice.Viewport.Width; i += (int)imageX + 4)
                {
                    if (i < GraphicsDevice.Viewport.Width - imageX)
                    {
                        Vector2 position = new Vector2(i, heightLevel);
                        bricks.Add(new Brick(image, position, tint));
                    }
                }

                heightLevel += imageY + 10;
                levelBricks.Add(bricks);
            }
        }

        public void drawBricks()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Scale = new Vector2(0.2f);
                bricks[i].Draw(spriteBatch);

            }
        }
    }
}
