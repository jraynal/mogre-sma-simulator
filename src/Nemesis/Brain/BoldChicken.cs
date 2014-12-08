using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class BoldChicken: Chicken
    {
        public BoldChicken() {
            base.fear = base.randVal(30); // Audacieux, moins de peur
        }

        public override void giveAdvice(List<Chicken> mates, List<Choice> choices) {
            // Donne son avis à tous ses copains
            if (!myChoiceOpinion.Any()) {
                makeMyChoiceOpinion(choices);
            }
            foreach (Chicken chick in mates) {
                chick.getAdvice(this, choices, myChoiceOpinion.First().choice);
            }
        }

        public override void getAdvice(Chicken chick, List<Choice> choices, Choice choice)
        {
            // Ecoute les avis des autres et les classes selon son propre ressentit
            foreach (OtherChicken foe in foes)
            {
                if (foe.chick.Equals(chick)) {
                    myChoiceOpinion.ForEach((possibleChoice op)=>op.changeOpinion(choice, -5));
                    myChoiceOpinion.Sort(sortChoices);
                    return;
                }
            }
            // chick était and les amis
            myChoiceOpinion.ForEach((possibleChoice op) => op.changeOpinion(choice, 5));
            myChoiceOpinion.Sort(sortChoices);
            return;
        }

        public override void vote(List<Vote> votes)
        {
            // Vote pour le premier des choix
            votes.ForEach((Vote vote) => vote.voted(myChoiceOpinion.First().choice));
        }

        public override void decide(Vote groupDecision, List<Choice> choices) {
            // Prend la direction de ses amis

            // Si la décision du groupe est différente de la mienne, je perd confiance
                // Si ma confiance est trop basse, je quitte le groupe, j'ai plus peur
            // Sinon Je suis content, ma confiance remonte

            // Si je suis seul je meurt
            myChoiceOpinion.Clear();
        }
    }
}
