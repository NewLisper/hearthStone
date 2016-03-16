using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Hero
    {
         public int Hp { get; set; }
         public String  Name { get; set; }
         public Hero(int hp, String name)
        {
            Hp = hp;
            Name = name;
        }
    }
}
