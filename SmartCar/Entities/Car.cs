using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SmartCar.Entities {
    public class Car : Entity {
        public static float TURN_SPEED = (1 / 16f);
        public static float ACCELERATION_RATE = (1 / 16f);
        public static float VELOCITY_FALLOFF = (1 / 32f);
        public static float MAX_VELOCITY = 3;
        public static float MAX_ACCELERATION = 1f;
        public enum Action { ACCELERATE, DECELERATE, TURN_LEFT, TURN_RIGHT };

        public float angle;
        public float acceleration;
        public float velocity;

        public Car(Texture2D sprite, Vector2 position, float angle) : base(sprite, position) {
            this.angle = 0;
            acceleration = 0;
            velocity = 0;
        }

        public void processActions(List<Action> actions) {
            // Should this be some other data structure, say a Map?
            foreach (Action action in actions) {
                switch (action) {
                    case Action.ACCELERATE:
                        acceleration += ACCELERATION_RATE;
                        break;
                    case Action.DECELERATE:
                        acceleration -= ACCELERATION_RATE;
                        break;
                    case Action.TURN_LEFT:
                        angle -= TURN_SPEED;
                        break;
                    case Action.TURN_RIGHT:
                        angle += TURN_SPEED;
                        break;
                    default:
                        continue;
                }
            }
            
            angle %= (float) (2 * System.Math.PI);
            acceleration = Math.clamp(acceleration, 0, MAX_ACCELERATION);
        }

        public void update() {
            velocity += acceleration;
            velocity = Math.clamp(velocity, -MAX_VELOCITY, MAX_VELOCITY);

            Vector2 movementVector = Math.radsToVector(angle);
            // Swap X and Y because the car's front is at pi/2.
            // Subtract the movement vector because (0, 0) is at the top-left.
            position.X -= movementVector.Y * velocity;
            position.Y -= movementVector.X * velocity;

            acceleration -= ACCELERATION_RATE / 2;
            // Using Math.Sign here in case driving in reverse is ever added in.
            velocity -= System.Math.Sign(velocity) * VELOCITY_FALLOFF;
            velocity = Math.clamp(velocity, 0, MAX_VELOCITY);
        }

        public new void draw(SpriteBatch batch) {
            batch.Draw(sprite, getRect(), null, Color.White, angle,
                new Vector2(sprite.Width / 2, sprite.Height / 2), SpriteEffects.None, 0);
        }
    }
}
