using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SmartCar.Entities;

namespace SmartCar {
    public class SmartCar : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprites sprites;

        Car car;
        Entity parkingSpace;

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

            car = new Car(sprites[Sprites.CAR], new Vector2(150, 150), 0);
            parkingSpace = new Entity(sprites[Sprites.EASY_PARKING], new Vector2(400, 275));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprites = new Sprites(Content);
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

            KeyboardState keyboard = Keyboard.GetState();
            List<Car.Action> actions = new List<Car.Action>();
            if (keyboard.IsKeyDown(Keys.Left)) actions.Add(Car.Action.TURN_LEFT);
            if (keyboard.IsKeyDown(Keys.Right)) actions.Add(Car.Action.TURN_RIGHT);
            if (keyboard.IsKeyDown(Keys.Up)) actions.Add(Car.Action.ACCELERATE);
            if (keyboard.IsKeyDown(Keys.Down)) actions.Add(Car.Action.DECELERATE);
            car.processActions(actions);
            car.update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            parkingSpace.draw(spriteBatch);
            car.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
