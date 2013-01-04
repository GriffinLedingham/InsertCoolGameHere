using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    abstract class Level
    {
        //public List<char[]> Grid;
        public Tile[,] Tiles;

        public int Width, Height;
        public int Difficulty, Items;

        public virtual void Generate() { }
        public virtual void Generate(string filename) { }

        public virtual void Draw()
        {

        }


    }
}
