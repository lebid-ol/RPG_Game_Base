using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace RPG_Game_Base
{
    public class Levels
    {
           private static int scoreToNextLevel = 100;
        public static void NextLevel(Player player, List<Monsters> upgradeMonsters, List<Monsters> listOfRemovedMonsters)
        {
            
            if (player.Experience >= scoreToNextLevel)
            {
                player.Level++;
                scoreToNextLevel += 100; // Увеличиваем порог для следующего уровня
                Console.WriteLine($"Поздравляем! Вы перешли на уровень {player.Level}!");

                // Обновление игрока при достижении нового уровня
                PlayerUpdate(player);

                // Обновление монстров при достижении нового уровня
                MonsterUpdate(player, upgradeMonsters, listOfRemovedMonsters);
            }
        }

        static void PlayerUpdate(Player player)
        {

            player.Health = player.Level * 60;
            player.Attack = player.Attack + 15;
            Console.WriteLine($"Ваше здоровье теперь: {player.Health}, ваша атака: {player.Attack}");

        }

        static List<Monsters> MonsterUpdate(Player player, List<Monsters> upgradeMonsters, List<Monsters> listOfRemovedMonsters)
        {
            Random random = new Random();

            for (int i = 0; i < listOfRemovedMonsters.Count; i++)
            {
                Monsters monster = listOfRemovedMonsters[i];

                int health = random.Next(player.Health / 2, player.Health + 20);
                int attack = random.Next(player.Attack / 2, player.Attack + 5);
                int gold = random.Next(player.Gold / 2, player.Gold + 5);
                int experience = random.Next(player.Experience / 2, player.Experience + 5);

                // Создаём нового монстра
                Monsters newMonster = new Monsters(monster.Name, health, attack, gold, experience);

                // Обновляем текущего монстра
                listOfRemovedMonsters[i] = newMonster;
            }

            upgradeMonsters.AddRange(listOfRemovedMonsters);
            Console.WriteLine($"Монстры обновлены! Теперь их уровень сложности соответствует уровню игрока {player.Level}.");

            return upgradeMonsters;
            }

        }

    }

