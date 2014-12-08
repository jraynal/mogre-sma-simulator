using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    abstract class Chicken
    {
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

        protected int fear;

        public Chicken(){}

        protected int randVal(int N) {
            return Program.GlobalRandomGenerator.Next(N);
        }

        public int getFear() {
            return this.fear;
        }

        public void discoverArea(List<Chicken> mates) {
            Console.WriteLine("I am discovering the area");
            foreach (Chicken chick in mates ) {
                if (!chick.Equals(this))
                {
                    int trust = randVal(100);
                    OtherChicken ochick = new OtherChicken();
                    ochick.chick = chick;
                    ochick.trust = trust;
                    Console.WriteLine(trust);
                    String message;
                    if (trust > 40) {
                        friends.Add(ochick);
                        message="Added Friend";
                    } else {
                        foes.Add(ochick);
                        message="Added Foe";
                    }
                    Console.WriteLine(message);
                }
            }
            Console.ReadLine();
        }

        public abstract void giveAdvice(List<Chicken> mates, List<Choice> choices);
        public abstract void getAdvice(Chicken chick, List<Choice> choices, Choice choice);
        public abstract void vote(List<Vote> votes);
        public abstract void decide(Vote groupDecision, List<Choice> choices);
    }
}
