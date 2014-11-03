using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    abstract class Chicken
    { 
        private struct OtherChicken {
            public Chicken chick;
            public int trust;
        };

        private List<OtherChicken> friends;
        private List<OtherChicken> foes;

        private int fear;

        public Chicken(){}

        private int randVal(int N) {
            Random rg = new System.Random();
            return rg.Next(N);
        }

        public void discoverArea(List<Chicken> mates) {
            foreach (Chicken chick in mates ) {
                int trust=randVal(100);
                OtherChicken ochick=new OtherChicken();
                ochick.chick = chick;
                ochick.trust = trust;
                if (trust > 50)
                    friends.Add(ochick);
                else
                    foes.Add(ochick);
            }
        }

        public void discuss();
        public void vote();
        public void decide();
    }
}
