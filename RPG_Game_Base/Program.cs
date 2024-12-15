using System.Collections.Generic;
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
        Player player = new Player(nameOfHero, 100, 10, 0, 0, 20, 1);

        //инвентарь игрока
        Item sword = new Item("Меч", 50, "Оружие", damage: 15); // Меч с уроном 15
        Item shield = new Item("Щит", 40, "Броня", armor: 10); // Щит с защитой 10
        Item potion = new Item("Лечебное зелье", 20, "Зелье", healthRestore: 25); // Зелье, восстанавливающее 25 здоровья

        //инвентарь в магазине
         Item swordShop = new Item("Меч рыцаря", 100, "Оружие", damage: 30); // Меч с уроном 30
         Item shieldShop = new Item("Щит героя", 100, "Броня", armor: 25); // Щит с защитой 25
         Item potionShop = new Item("Зелье исцеления", 40, "Зелье", healthRestore: 70); // Зелье, восстанавливающее 70 здоровья
         Item axeShop = new Item("Боевой топор", 150, "Оружие", damage: 50); // Топор с уроном 50

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
                    Monsters chosenMonster = Battle.ChooseMonsterForBattle(selectedMonsters);
                    Battle.FightMonster(player, chosenMonster);
                    Monsters.RemoveMonster(upgradeMonsters, chosenMonster.CharacterId);
                    Levels.NextLevel(player, upgradeMonsters, listOfRemovedMonsters);
                    break;
                case "2":
                    // Поход в магазин
                    Console.WriteLine("Добро пожаловать в магазин! Доступные товары:");
                    Console.Write("1. ");
                    swordShop.DisplayInventory();
                    Console.Write("2. ");
                    shieldShop.DisplayInventory();
                    Console.Write("3. ");
                    potionShop.DisplayInventory();
                    Console.Write("4. ");
                    axeShop.DisplayInventory();
                    Console.WriteLine();
                    Console.WriteLine("Выберите инвентарь для покупки:");
                    break;
                case "3":
                    // Отобразить инвентарь игрока
                    Console.WriteLine("Информация об инвентаре:");
                    sword.DisplayInventory();
                    Console.WriteLine();
                    shield.DisplayInventory();
                    Console.WriteLine();
                    potion.DisplayInventory();
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
