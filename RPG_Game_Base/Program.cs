using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace RPG_Game_Base;

public static class Program
{
    public static List<Monsters> listOfRemovedMonsters = new List<Monsters>();
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
        Player player = new Player(nameOfHero, 100, 15, 40, 5, 0, 1);

        //инвентарь игрока
        Item sword = new Item("Меч", cost: 0, "Оружие", damage: 15); // Меч с уроном 15
                

    int level = 1;

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
                    Monsters chosenMonster = Battle.ChooseMonsterForBattle(player,selectedMonsters);
                    Battle.FightMonster(player, chosenMonster);
                    Monsters.RemoveMonster(upgradeMonsters, chosenMonster.CharacterId);
                    Levels.NextLevel(player, upgradeMonsters, listOfRemovedMonsters);
                    break;
                case "2":
                    // Поход в магазин
                    Console.WriteLine("Выберите инвентарь для покупки:");
                    Shop.BuyItem(player);
                    break;
                case "3":
                    // Отобразить инвентарь игрока
                    Console.WriteLine("Информация об инвентаре:");
                    sword.DisplayInventory();
                    Console.WriteLine();
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

}
