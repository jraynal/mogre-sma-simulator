using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class Choice
    {
        private int votes;
        private Coord dir;
        public Choice(Coord dir) {
            this.dir = dir;
        }

        public Coord getDir() {
            return dir;
        }

        public void vote() {
            this.votes++;
        }

        public int getVotes() {
            return votes;
        }
    }
}
