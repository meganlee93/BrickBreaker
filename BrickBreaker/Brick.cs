using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Brick : Sprite
    {
        public Brick(Texture2D Image, Vector2 position, Color tint) : base(Image, position, tint)
        {

        }
    }
}
