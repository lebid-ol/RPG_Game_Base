﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    internal class Battle
    {
        public static void FightMonster(Player player, List<Monsters> selectedMonsters)
        {

            Console.WriteLine("Выберите из списка монстра, с которым желаете сразиться: ");

            for (int i = 0; i < selectedMonsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedMonsters[i].Name}, здоровье: {selectedMonsters[i].Health}, атака: {selectedMonsters[i].Attack}, золото: {selectedMonsters[i].Gold}, опыт: {selectedMonsters[i].Experience}");

            }

            int choice;

            while (true)
            {
                Console.Write("Введите номер монстра: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= selectedMonsters.Count)
                {
                    break;
                }
                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
            }

            Monsters chosenMonster = selectedMonsters[choice - 1];
            Console.WriteLine($"Вы выбрали монстра: {chosenMonster.Name}");
            Console.WriteLine("Битва начинается!");

            while (chosenMonster.Health > 0 && player.Health > 0)
            {

                Console.WriteLine($"{player.Name} наносит урон {player.Attack} по {chosenMonster.Name}.");
                chosenMonster.Health -= player.Attack;
                Thread.Sleep(1000);

                // Атака игрока
                if (chosenMonster.Health <= 0)
                {
                    Console.WriteLine($"{chosenMonster.Name} побежден! Вы получаете {chosenMonster.Gold} золота и {chosenMonster.Experience} опыта.");
                    player.Gold += chosenMonster.Gold;
                    player.Experience += chosenMonster.Experience;
                    Thread.Sleep(6000);
                    break;
                }

                // Атака монстра
                Console.WriteLine($"{chosenMonster.Name} атакует и наносит {chosenMonster.Attack} урона {player.Name}.");
                player.Health -= chosenMonster.Attack;
                Thread.Sleep(1000);

                if (player.Health <= 0)
                {
                    Console.WriteLine($"{player.Name} пал в бою.");
                    Console.WriteLine("Игра закончена");
                    Thread.Sleep(6000);
                    Environment.Exit(0);
                }
            }

            Console.Clear();
            Console.WriteLine("Вы сразились с монстром!");
        }
    }
}
