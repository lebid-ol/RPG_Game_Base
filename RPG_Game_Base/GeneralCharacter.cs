using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    public abstract class GeneralCharacter
    {
        public Guid CharacterId { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }

        public GeneralCharacter(string name, int health, int attack, int gold, int experience)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Gold = gold;
            Experience = experience;

        }


    }
}
