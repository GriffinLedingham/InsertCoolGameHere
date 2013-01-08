using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Felicitas
{
    class FileGenerated : Level
    {
        public FileGenerated()
        {
        }

        public override void Generate(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            //TODO: Add try parse.
            
            string line = string.Empty;
            line = reader.ReadLine();
            int tempDimension = int.Parse(line);
            Width = tempDimension;
            tempDimension = int.Parse(line);
            Height = tempDimension;

            Tiles = new Tile[Width, Height];

            int curRow = 0;

            while ((line = reader.ReadLine()) != null)
            {
                for (int curCol = 0; curCol < Width; curCol++)
                {
                    Tiles[curRow, curCol] = GetTile(line[curCol],curCol,curRow);
                }
                curRow++;
            }

        }

        private Tile GetTile(char c, int curCol, int curRow)
        {
            switch (c)
            {
                case '0': return new BlankTile(curCol, curRow, null);
                default: return new BasicTile(curCol, curRow, Platformer.BasicTileTexture);
            }
        }


        public override void Draw()
        {
            base.Draw();
        }


    }
}
