using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    class BasicTile : Tile
    {
        public BasicTile(int x, int y, Texture2D texture)
            : base(x, y, texture)
        {

        }

        public override void Draw()
        {
 	        base.Draw();
        }

        public override bool CheckCollision(Player player)
        {
            //throw new Exception("Implement check collision");
            float leftA, leftB;
            float rightA, rightB;
            float topA, topB;
            float bottomA, bottomB;

            leftA = Pos.X * SpriteTexture.Width;
            rightA = Pos.X * SpriteTexture.Width + SpriteTexture.Width;
            topA = Pos.Y * SpriteTexture.Height;
            bottomA = Pos.Y * SpriteTexture.Height + SpriteTexture.Height;

            leftB = player.Pos.X;
            rightB = player.Pos.X + player.SpriteTexture.Width;
            topB = player.Pos.Y;
            bottomB = player.Pos.Y + player.SpriteTexture.Height;

            if (bottomA <= topB)
            {
                return false;
            }
            if (topA >= bottomB)
            {
                return false;
            }
            if (rightA <= leftB)
            {
                return false;
            }
            if (leftA >= rightB)
            {
                return false;
            }
            return true;
        }
        
    }
}