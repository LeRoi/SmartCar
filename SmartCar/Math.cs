using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SmartCar {
    public class Math {
        public static float clamp(float num, float min, float max) {
            return (num < min) ? min : ((num > max) ? max : num);
        }

        public static Vector2 radsToVector(float radians) {
            return new Vector2((float) System.Math.Cos(radians),
                -(float) System.Math.Sin(radians));
        }
    }
}
