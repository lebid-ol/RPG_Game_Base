using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    internal class Monsters : IGlobalCharacter
    {
        public string Name { get; set; }    
        public double Health { get; set; }
        public double Attack { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }

        internal Monsters(string name, double health, double attack, int gold, int experience)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Gold = gold;
            Experience = experience;

        }

        static string[] monsters = {
            "Тенекрылый Разрушитель",
            "Огненный Жевун",
            "Камнегрыз",
            "Холодный Призрак",
            "Мракоклык",
            "Ледяной Драугр",
            "Кровавый Пожиратель",
            "Болотный Шептун",
            "Тенемор",
            "Шквальный Ревун",
            "Гнилокожий Слуга",
            "Сквернохват",
            "Пепельный Дух",
            "Скрежетник",
            "Безликий Топтун",
            "Огнекост",
            "Древний Жнец",
            "Стальной Пасть",
            "Чумной Костолом",
            "Лунный Оборотень"};

        public static Monsters CreateRandomMonster()
        {
            Random random = new Random();
            string randomName = monsters[random.Next(monsters.Length)];
            double health = random.Next(40, 120);
            double attack = random.Next(5, 15);
            int gold = random.Next(5, 20);
            int experience = random.Next(1, 5);

            return new Monsters(randomName, health, attack, gold, experience);
        }




    }
    }

