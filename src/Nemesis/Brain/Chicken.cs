using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    abstract class Chicken
    {
        private Coord pos;
        private Coord goal;
        protected int fear;
        protected int groupAverageTrust=0;
        protected List<possibleChoice> myChoiceOpinion = new List<possibleChoice>();
        protected List<OtherChicken> friends = new List<OtherChicken>();
        protected List<OtherChicken> foes = new List<OtherChicken>();
        protected struct OtherChicken {
            public Chicken chick;
            public int trust;
        };

        protected class possibleChoice
        {
            public Choice choice;
            public int opinion;
            public possibleChoice(Choice choice, int opinion)
            {
                this.choice = choice;
                this.opinion = opinion;
            }
            public void changeOpinion(Choice choice, int modif) {
                if (this.choice.Equals(choice)) {
                    this.opinion += modif;
                }
            } 
        };

        protected int sortChoices(possibleChoice A, possibleChoice B)
        {

            if (A.opinion > B.opinion)
                return 1;
            return 0;
        }

        protected void makeMyChoiceOpinion(List<Choice> choices)
        {
            foreach (Choice choice in choices)
            {
                possibleChoice op = new possibleChoice(choice, randVal(50) - 25);
                myChoiceOpinion.Add(op);
            }
            myChoiceOpinion.Sort(sortChoices);
        }

        public Chicken(){}

        protected int randVal(int N) {
            return Program.GlobalRandomGenerator.Next(N);
        }

        public int getFear() {
            return this.fear;
        }

        public void discoverArea(List<Chicken> mates) {
            int trustSum=0, count=1;
            foreach (Chicken chick in mates ) {
                if (!chick.Equals(this))
                {
                    int trust = randVal(100);
                    OtherChicken ochick = new OtherChicken();
                    ochick.chick = chick;
                    ochick.trust = trust;
                    if (trust > 40) {
                        friends.Add(ochick);
                    } else {
                        foes.Add(ochick);
                    }
                    trustSum += trust;
                    count++;
                }
            }
            groupAverageTrust = trustSum / count;
        }

        public Coord getPos() {
            return this.pos;
        }

        public Coord getGoal() {
            return this.goal;
        }

        public void updateGoal(Coord pos) {
            this.pos = this.goal;
            this.goal = pos;
            return;
        }

        public abstract void giveAdvice(List<Chicken> mates, List<Choice> choices);
        public abstract void getAdvice(Chicken chick, List<Choice> choices, Choice choice);
        public abstract void vote();
        public abstract void decide(Choice groupVote);
    }
}
