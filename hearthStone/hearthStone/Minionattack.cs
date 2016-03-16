using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Minionattack : IAction
    {
        private Game RGame { get; set; }
        private int Indexminion { get; set; }
        private int Indexenemy { get; set; }
        public Minionattack(Game game, int indexminion, int indexenemy)
        {
            RGame = game;
            Indexminion = indexminion;
            Indexenemy = indexenemy;
        }
        public void perform()
        {
            List<Card> minions, enemies;
            Hero hero;
            if (RGame.Whichuser)
            {
                minions = RGame.TGround.Item1;
                enemies = RGame.TGround.Item2;
                hero = RGame.THero.Item2;
            }
            else
            {
                minions = RGame.TGround.Item2;
                enemies = RGame.TGround.Item1;
                hero = RGame.THero.Item1;
            }
            Card minion = minions[Indexminion];
            if (Indexenemy == 7)
            {
                hero.Hp -= minion.Attack;
                minion.Sleep = true;
            }
            else if (Indexenemy >= 0 && Indexenemy <= 6)
            {
                Card enemy = enemies[Indexenemy];
                minion.Hp -= enemy.Attack;
                enemy.Hp -= minion.Attack;
                if (minion.Hp <= 0) minions.RemoveAt(Indexminion);
                if (enemy.Hp <= 0) enemies.RemoveAt(Indexenemy);
            }
            else
            {
                Console.WriteLine("Invalid Index of enemy");
            }
        }
    }
}
