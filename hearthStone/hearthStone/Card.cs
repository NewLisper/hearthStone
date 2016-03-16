using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Card
    {
        public int Crystalcost { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public bool Sleep { get; set; }
        public Card(int crystalcost, int hp, int attack)
        {
            Crystalcost = crystalcost;
            Hp = hp;
            Attack = attack;
            Sleep = true;
        }
    }
}
