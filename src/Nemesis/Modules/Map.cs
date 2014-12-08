using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Modules
{
    class Map
    {
        private int mWidth = 0;
        private int mHeight = 0;
        private List<List<Tile>> mTiles = new List<List<Tile>>();

        Map(int width, int height)
        {
            mWidth = width;
            mHeight = height;
            for (int i = 0; i < mHeight; i++)
            {
                List<Tile> row = new List<Tile>();
                for (int j = 0; j < mWidth; j++) {
                    row.Add(new Tile());
                }
                mTiles.Add(row);
            }
        }

        public int width()
        {
            return mWidth;
        }

        /*public void setWidth(int width)
        {
            mWidth = width;
        }*/

        public int height()
        {
            return mHeight;
        }

        /*public void setHeight(int height)
        {
            mHeight = height;
        }*/

        public Tile tile(Coord coord)
        {
            return mTiles[coord.y()][coord.x()];
        }
    }
}
