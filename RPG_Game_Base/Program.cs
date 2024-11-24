using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPG_Game_Base;

public static class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;
        Console.WriteLine("Добро пожаловать в консольную RPG!");
        Console.WriteLine();
        Console.Write("Назовите героя: ");
        string? nameOfHero = Console.ReadLine();

        while (string.IsNullOrEmpty(nameOfHero))
        {
            Console.WriteLine("Игрок обязан иметь имя. Введите имя");
            nameOfHero = Console.ReadLine();
        }

        // Создаем игрока
        Player player = new Player(nameOfHero, 100, 10, 0, 0, 20, 1);

        List <Monsters> upgradeMonsters = Monsters.UpgradeMonster(player);



        while (true)
        {
            Console.WriteLine("\nГлавное меню:");
            Console.WriteLine("1. Бой с монстром");
            Console.WriteLine("2. Поход в магазин");
            Console.WriteLine("3. Инвентарь");
            Console.WriteLine("4. Выход");
            
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Начать бой с монстром
                    List<Monsters> selectedMonsters = Monsters.GetRandomMonster(upgradeMonsters);
                    Monsters chosenMonster = Battle.ChooseMonsterForBattle(selectedMonsters);
                    Battle.FightMonster(player, chosenMonster);
                    Monsters.RemoveMonster(upgradeMonsters, chosenMonster.CharacterId);
                    break;
                case "2":
                    // Поход в магазин
                    VisitShop(player);
                    break;
                case "3":
                    // Отобразить инвентарь игрока
                    DisplayInventory(player);
                    break;
                case "4":
                    // Выход из игры
                    Console.WriteLine("Спасибо за игру. До свидания!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Выберите действие из списка.");
                    break;
            }
        }
    }

    static void VisitShop(Player player)
    {
        // Здесь вы можете реализовать магазин, где игрок может покупать предметы, оружие и броню.
        Console.WriteLine("Добро пожаловать в магазин!");
    }

    static void DisplayInventory(Player player)
    {
        // Здесь вы можете отобразить инвентарь игрока, его текущее здоровье, атаку, золото и другие параметры.
        Console.WriteLine("Инвентарь игрока:");
    }
}