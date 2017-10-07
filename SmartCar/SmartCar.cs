using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SmartCar {
    public class SmartCar : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprites sprites;

        Car car;

        public class Car {
            public Texture2D sprite;
            public Vector2 position;
            public float angle;

            public Car(Texture2D sprite, Vector2 position) {
                this.sprite = sprite;
                this.position = position;
                this.angle = 0;
            }

            public Rectangle getRect() {
                return new Rectangle((int) position.X, (int) position.Y,
                    sprite.Width, sprite.Height);
            }

            public void draw(SpriteBatch batch) {
                batch.Draw(sprite, getRect(), null, Color.White, angle,
                    new Vector2(sprite.Width / 2, sprite.Height / 2), SpriteEffects.None, 0);
                // batch.Draw(sprite, getRect(), Color.White);
            }
        }
        
        public SmartCar() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();

            car = new Car(sprites[Sprites.CAR], new Vector2(150, 150));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprites = new Sprites(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            car.angle += 0.125f;
            car.angle %= 360;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            car.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
