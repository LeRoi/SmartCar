using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SmartCar {
    public class Sprites {
        public static string CAR = "car";
        public static string EASY_PARKING = "easy_parking";
        public static string HARD_PARKING = "hard_parking";

        private Dictionary<String, Texture2D> sprites;

        public Sprites(ContentManager content) {
            sprites = new Dictionary<string, Texture2D>();
            sprites[CAR] = content.Load<Texture2D>("sprites/yellow_sportscar");
            sprites[EASY_PARKING] = content.Load<Texture2D>("sprites/parking_space_easy");
            sprites[HARD_PARKING] = content.Load<Texture2D>("sprites/parking_space_hard");
        }

        public Texture2D this[string key] {
            get { return sprites[key]; }
            set { sprites[key] = value; }
        }
    }
}
