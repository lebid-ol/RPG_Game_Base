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
                    FightMonster(player);
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

    static void FightMonster(Player player)
    {
        Monsters monsterOne = Monsters.CreateRandomMonster();
        Monsters monsterSecond = Monsters.CreateRandomMonster();
        Monsters monsterThird = Monsters.CreateRandomMonster();
        Monsters monsterFourth = Monsters.CreateRandomMonster();
        Monsters monsterFifth = Monsters.CreateRandomMonster();

        Console.WriteLine("Выберите из списка монстра, с которым желаете сразиться: ");
        Console.WriteLine("1. " + monsterOne.Name);
        Console.WriteLine("2. " + monsterSecond.Name);
        Console.WriteLine("3. " + monsterThird.Name);
        Console.WriteLine("4. " + monsterFourth.Name);
        Console.WriteLine("5. " + monsterFifth.Name);
        Console.Write("Ваш выбор: ");
        string? choiceMonster = Console.ReadLine();

        switch (choiceMonster)
        {
            case "1":
                Console.WriteLine("Бой начался!");
                while (monsterOne.Health > 0 && player.Health > 0)
                {

                    Console.WriteLine($"{player.Name} наносит урон {player.Attack} по {monsterOne.Name}.");
                    monsterOne.Health -= player.Attack;
                    Thread.Sleep(1000);

                    // Атака игрока
                    if (monsterOne.Health <= 0)
                    {
                        Console.WriteLine($"{monsterOne.Name} побежден! Вы получаете {monsterOne.Gold} золота и {monsterOne.Experience} опыта.");
                        player.Gold += monsterOne.Gold;
                        player.Experience += monsterOne.Experience;
                        Thread.Sleep(1000);
                        break;
                    }

                    // Атака монстра
                    Console.WriteLine($"{monsterOne.Name} атакует и наносит {monsterOne.Attack} урона {player.Name}.");
                    player.Health -= monsterOne.Attack;
                    Thread.Sleep(1000);

                    if (player.Health <= 0)
                    {
                        Console.WriteLine($"{player.Name} пал в бою.");
                        Thread.Sleep(1000);
                        break;
                    }
                }

                Console.Clear();
                Console.WriteLine("Вы сразились с монстром!");
                break;
            case "2":
                
                break;
            case "3":
                
                break;
            case "4":
                
                break;
            case "5":

                break;
            default:
                Console.WriteLine("Выберите монстра из списка.");
                break;
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