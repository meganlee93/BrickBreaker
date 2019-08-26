using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Paddle : Sprite
    {
        public Paddle(Texture2D image, Vector2 position, Color tint) : base(image, position, tint)
        {

        }

        public void Update(KeyboardState state, int width)
        {
            //Need to accelerate
            if(state.IsKeyDown(Keys.Left) && Position.X > 0)
            {
                Position.X -= 8;
            }

            else if(state.IsKeyDown(Keys.Right) && Position.X + (Image.Width * Scale.X) < width)
            {
                Position.X += 8;
            }
        }
    }
}
