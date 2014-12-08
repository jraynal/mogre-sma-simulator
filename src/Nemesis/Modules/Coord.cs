using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Modules
{
    class Coord
    {
        private int mX = 0;
        private int mY = 0;

        public Coord(int x, int y)
        {
            mX = x;
            mY = y;
        }

        public int x()
        {
            return mX;
        }

        public void setX(int x)
        {
            mX = x;
        }

        public int y()
        {
            return mY;
        }

        public void setY(int y)
        {
            mY = y;
        }
    }
}
