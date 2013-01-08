using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    class Player
    {
        public Vector2 Pos,Velocity;
        public Texture2D SpriteTexture;
        float AccelerationY = -0.3f;
        bool Jumping = true;

        public Player(int x, int y, Texture2D texture)
        {
            SpriteTexture = texture;
            Pos.Y = y;
            Jumping = true;
            Pos.X = x;

            //TODO: Add collision detection which bumps character up if spawned on a tile.
        }

    }
}
