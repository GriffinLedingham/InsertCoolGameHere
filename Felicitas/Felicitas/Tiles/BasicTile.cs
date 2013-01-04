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
            return true;
        }
        
    }
}
