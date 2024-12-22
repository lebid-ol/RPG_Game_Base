using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    public class Monsters : GeneralCharacter
    {

        public Monsters(string name, int health, int attack, int gold, int experience) : base (name, health, attack,  gold,  experience)
        {
           
        
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

        public static List <Monsters> UpgradeMonster(Player player)
        {
            Random random = new Random();
            List <Monsters> upgradeMonsters = new List<Monsters>();

            foreach (string monster in monsters)
            {
                int health = random.Next(player.Health/2, player.Health + 20);
                int attack = random.Next(player.Attack/2, player.Attack + 15);
                int gold = random.Next(40, 150);
                int experience = random.Next(10, 30);
                Monsters newMonster = new Monsters(monster, health, attack, gold, experience);
                upgradeMonsters.Add(newMonster);
            }

            return upgradeMonsters;
            
        }
        public static List<Monsters> GetRandomMonster(List<Monsters> upgradeMonsters)
        {
            if (upgradeMonsters == null || upgradeMonsters.Count == 0)
            {
                throw new InvalidOperationException("Список монстров пуст. Невозможно выбрать случайного монстра.");
            }

            List<Monsters> selectedMonsters = new List<Monsters>();
            Random random = new Random();
            List<Monsters> tempList = new List<Monsters>(upgradeMonsters); // Копируем список, чтобы удалять выбранных

            if (upgradeMonsters.Count > 4)
            {
                for (int i = 0; i < 5; i++)
                {
                    int randomIndex = random.Next(tempList.Count);
                    selectedMonsters.Add(tempList[randomIndex]); // Добавляем выбранного монстра
                    tempList.RemoveAt(randomIndex);             // Удаляем выбранного монстра из временного списка

                }
                return selectedMonsters;//возвращаем список с пяти монстров
            }
            else
            {
                for (int i = 0; i < upgradeMonsters.Count; i++)
                {
                    int randomIndex = random.Next(tempList.Count);
                    selectedMonsters.Add(tempList[randomIndex]); // Добавляем выбранного монстра
                    tempList.RemoveAt(randomIndex);             // Удаляем выбранного монстра из временного списка
                }
                return selectedMonsters;//возвращаем список с оставшихся монстров 
            }

        }

        public static (List<Monsters> updatedMonsters, List<Monsters> removedMonsters) RemoveMonster(List<Monsters> upgradeMonsters, Guid chosenMonster)
        {

            var monsterToRemove = upgradeMonsters.FirstOrDefault(upgradeMonsters => upgradeMonsters.CharacterId == chosenMonster);
            
            if (monsterToRemove != null)
            {
               upgradeMonsters.Remove(monsterToRemove);
               Program.listOfRemovedMonsters.Add(monsterToRemove);

            }
            else
            {
                Console.WriteLine("Монстр не найден.");
            }

            return (upgradeMonsters, Program.listOfRemovedMonsters);

        }

    }
}

