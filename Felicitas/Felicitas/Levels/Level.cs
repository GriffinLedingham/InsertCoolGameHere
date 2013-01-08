using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    abstract class Level
    {

        public Tile[,] Tiles;

        public int Width, Height;
        //TODO: Don't use static number for Width/Height
        public static float TileWidth = 32;
        public static float TileHeight = 32;
        public int Difficulty, Items;
        

        public virtual void Generate() { throw new Exception("Generate not implemented"); }
        public virtual void Generate(string filename) { throw new Exception("Generate not implemented"); }

        public virtual void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Tiles[i, j].Draw();
                }
            }
        }


    }
}
