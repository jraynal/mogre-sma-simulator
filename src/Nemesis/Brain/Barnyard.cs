using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class Barnyard
    {
        public List<List<Chicken>> chickens = new List<List<Chicken>>();
        public Barnyard(){
            Console.WriteLine("Initialsing Barnyard");
            List<Chicken> firstGroup=new List<Chicken>();
            for (int i = 0; i < 10; i++) {
                firstGroup.Add(new BoldChicken());
            }
            Console.WriteLine("Chickens discover area");
            firstGroup.ForEach((Chicken chick) => chick.discoverArea(firstGroup));
            chickens.Add(firstGroup);
            Console.WriteLine("Let's explore!");
        }

        public Barnyard(List<List<Chicken>> chickens) {
            this.chickens=chickens;
            chickens.ForEach((List<Chicken> group) => group.ForEach(
                                   (Chicken chick) => chick.discoverArea(group)));
        }


        // Une étape doit prendre en argument une Map
        public void step(Map map)
        {
            foreach (List<Chicken> group in chickens)
            {
                List<Choice> choices = new List<Choice>();
                List<Coord> neighbours = map.getTile(group.First().getPos()).getNeighbour();
                foreach (Coord neighbour in neighbours)
                {
                    Choice choice = new Choice(neighbour);
                    choices.Add(choice);
                }
                foreach (Chicken chick in group) {
                    // Phase 1: Discussion
                    chick.giveAdvice(group, choices);

                    // Phase 2: Vote
                    chick.vote();
                    Choice groupChoice = choices.First();
                    foreach (Choice vote in choices) {
                        if (groupChoice.getVotes() < vote.getVotes())
                            groupChoice = vote;
                    }

                    // Phase 3: Décision
                    chick.decide(groupChoice);
                    // Debug
                    choices.ForEach((Choice vote) => Console.WriteLine(vote.getVotes()));
                    choices.Clear();
                }
            }
        }
    }
}
