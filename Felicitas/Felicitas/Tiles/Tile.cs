using SharpDX;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    abstract class Tile
    {
        public Texture2D SpriteTexture;
        /// <summary>
        /// This is the position in the array, not the position in the world.
        /// </summary>
        public Vector2 Pos;
        public int Width, Height;
      
        public Tile(int x, int y, Texture2D texture)
        {
            Pos.X = x;
            Pos.Y = y;
            if (texture != null)
            {
                Width = texture.Width;
                Height = texture.Height;
            }
            SpriteTexture = texture;
        }

        public virtual void Draw()
        {
            Platformer.spriteBatch.Begin();
            if (SpriteTexture != null)
            {
                Platformer.spriteBatch.Draw(SpriteTexture, new Vector2(Width, Height) * Pos, Color.White);
            }
            Platformer.spriteBatch.End();
        }

        public virtual bool CheckCollision(Player player)
        {
            throw new Exception("Implement check collision");
        }

    }
}
