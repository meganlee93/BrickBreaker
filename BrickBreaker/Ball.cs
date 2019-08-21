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
        private int xSpeed = 5;
        private int ySpeed = 5;
        public Ball(Texture2D image, Vector2 position, Color tint) : base(image, position, tint)
        {

        }

        public void Update(int width, int height)
        {

        }
    }
}
