using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Ball : Sprite
    {
        private int xSpeed = -5;
        private int ySpeed = 5;
        public bool NewBall { get; set; } = true;
        public Ball(Texture2D image, Vector2 position, Color tint) : base(image, position, tint)
        {

        }

        public void Update(int width, int height, Paddle paddle)
        {
            Position.X += xSpeed;
            Position.Y += ySpeed;

            //need brick and paddle collision
            if(Position.X < 0)
            {
                xSpeed = Math.Abs(xSpeed);
            }

            else if(Position.X + (Image.Width * Scale.X) > width)
            {
                xSpeed = -Math.Abs(xSpeed);
            }

            if(Position.Y + (Image.Height * Scale.Y) > paddle.Position.Y && Position.X + (Image.Width * Scale.X) < paddle.Position.X + (paddle.Image.Width * paddle.Scale.X)
                && Position.X > paddle.Position.X)
            {
                ySpeed = -Math.Abs(ySpeed);
            }

            if(Position.Y + (Image.Height * Scale.Y) > height)
            {
                Position.X = width / 2 - (Image.Width / 2 * Scale.X);
                Position.Y = height / 2 - (Image.Height / 2 * Scale.Y);
                NewBall = true;
            }
            else if(Position.Y < 0)
            {
                ySpeed = Math.Abs(ySpeed);
            }
        }
    }
}
