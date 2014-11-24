using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class Vote
    {
        private Choice choice;
        private int votes;

        public Vote(Choice choice) {
            this.choice = choice;
            this.votes = 0;
        }
        public void voted(Choice choice) {
            if (this.choice.Equals(choice)) {
                this.votes++;
            }
        }
        public int getVotes() {
            return this.votes;
        }
    }
}
