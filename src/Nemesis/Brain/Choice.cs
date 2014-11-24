using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis.Brain
{
    class Choice
    {
        private int value;

        public Choice(int value) {
            this.value = value;
        }

        public int getVal() {
            return value;
        }
    }
}
