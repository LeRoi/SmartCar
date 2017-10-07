using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmartCar.Entities {
    public class Entity {
        public Texture2D sprite;
        public Vector2 position;

        public Entity(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
        }

        public Rectangle getRect() {
            return new Rectangle((int) position.X, (int) position.Y,
                sprite.Width, sprite.Height);
        }

        public void draw(SpriteBatch batch) {
            batch.Draw(sprite, getRect(), Color.White);
        }
    }
}
