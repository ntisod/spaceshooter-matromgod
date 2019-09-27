using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    /// <summary>
    /// Matheos space shooter.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        //Variabler
        Texture2D ship_texture;
        Vector2 ship_vector; //Rymdsheppets position
        Vector2 ship_speed; //Rymdsheppets hastighet

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
            ship_vector.X = 380;
            ship_vector.Y = 400;

            ship_speed.X = 50f;
            ship_speed.Y = 50f;


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            ship_texture = Content.Load<Texture2D>("ship");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            KeyboardState keyboardState = Keyboard.GetState();

            if (ship_vector.X <= Window.ClientBounds.Width - ship_texture.Width && ship_vector.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                    ship_vector.X += ship_speed.X;
                if (keyboardState.IsKeyDown(Keys.Left))
                    ship_vector.X -= ship_speed.X;
            }

            if (ship_vector.Y <= Window.ClientBounds.Height - ship_texture.Height && ship_vector.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                    ship_vector.Y += ship_speed.Y;
                if (keyboardState.IsKeyDown(Keys.Up))
                    ship_vector.Y -= ship_speed.Y;
            }

            if (ship_vector.X < 0)
                ship_vector.X = 0;
            if (ship_vector.X > Window.ClientBounds.Width - ship_texture.Width)
            {
                ship_vector.X = Window.ClientBounds.Width - ship_texture.Width;
            }

            if (ship_vector.Y < 0)
                ship_vector.Y = 0;
            if (ship_vector.Y > Window.ClientBounds.Height - ship_texture.Height)
            {
                ship_vector.Y = Window.ClientBounds.Height - ship_texture.Height;
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

            // TODO: Add your drawing code here'
            spriteBatch.Begin();
            spriteBatch.Draw(ship_texture, ship_vector, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
