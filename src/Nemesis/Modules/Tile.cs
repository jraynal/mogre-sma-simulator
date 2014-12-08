using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Modules
{
    class Tile
    {
        public enum Neighbour { NORTH, SOUTH, EAST, WEST };

        private Coord mPos;
        private List<Neighbour> mNeighbours = new List<Neighbour>();

        public Coord pos()
        {
            return mPos;
        }

        public void setPos(Coord pos)
        {
            mPos = pos;
        }

        public List<Neighbour> neighbours()
        {
            return mNeighbours;
        }

        public List<Coord> neighboursCoords()
        {
            List<Coord> coords = new List<Coord>();
            if (mNeighbours.Contains(Neighbour.NORTH))
            {
                coords.Add(new Coord(mPos.x(), mPos.y() - 1));
            }
            if (mNeighbours.Contains(Neighbour.SOUTH))
            {
                coords.Add(new Coord(mPos.x(), mPos.y() + 1));
            }
            if (mNeighbours.Contains(Neighbour.WEST))
            {
                coords.Add(new Coord(mPos.x() - 1, mPos.y()));
            }
            if (mNeighbours.Contains(Neighbour.EAST))
            {
                coords.Add(new Coord(mPos.x() + 1, mPos.y()));
            }
            return coords;
        }

        public void addNeighbour(Neighbour neighbour)
        {
            if (!mNeighbours.Contains(neighbour))
            {
                mNeighbours.Add(neighbour);
            }
        }
    }
}
