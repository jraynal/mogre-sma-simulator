using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class BolzyChicken: Chicken
    {
        public BolzyChicken() {
            base.fear = base.randVal(30); // Audacieux, moins de peur
        }

        public override void giveAdvice(List<Chicken> mates, List<Choice> choices) {
            // Donne son avis à tous ses copains
        }
        public override void getAdvice(Chicken chick, Choice choice) {
            // Ecoute les avis des autres et les classes selon son propre ressentit
        }

        public override void vote(List<Choice> choices) {
            // Vote pour le premier des choix
        }

        public override void decide(List<Vote> votes, List<Choice> choices) {
            // Prend la direction de ses amis
        }
    }
}
