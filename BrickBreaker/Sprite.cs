using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Sprite
    {
        private Vector2 position;
        public Texture2D Image { get; set; }
        public ref Vector2 Position => ref position;
        public Color Tint { get; set; }
        public Vector2 Scale { get; set; } = Vector2.One;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)(Image.Width * Scale.X), (int)(Image.Height * Scale.Y));
            }
        }


        public Sprite(Texture2D image, Vector2 position, Color tint)
        {
            Image = image;
            Position = position;
            Tint = tint;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Tint, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
