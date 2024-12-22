using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace RPG_Game_Base
{
    public class Shop
    {
        //инвентарь в магазине
        static Item swordShop = new Item("Меч рыцаря", 120, "Оружие", damage: 45); // Меч с уроном 45
        static Item shieldShop = new Item("Щит героя", 100, "Броня", armor: 25); // Щит с защитой 25
        static Item potionShop = new Item("Зелье исцеления", 40, "Зелье", healthRestore: 100); // Зелье, восстанавливающее 100 здоровья
        static Item axeShop = new Item("Боевой топор", 150, "Оружие", damage: 65); // Топор с уроном 65

        public static void BuyItem(Player player)
        { 
            bool exitFromShop = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ваши основные характеристики до покупки инвентаря: ");
            Console.WriteLine($"Здоровье: {player.Health}, Атака : {player.Attack}, Золото : {player.Gold}, Броня : {player.Armor}");
            Console.ResetColor();
            Console.WriteLine();

            while (!exitFromShop)
            {
                Console.Write("1. ");
                swordShop.DisplayInventory();
                Console.WriteLine();

                Console.Write("2. ");
                shieldShop.DisplayInventory();
                Console.WriteLine();

                Console.Write("3. ");
                potionShop.DisplayInventory();
                Console.WriteLine();

                Console.Write("4. ");
                axeShop.DisplayInventory();
                Console.WriteLine();

                Console.Write("5. Выход с магазина");
                Console.WriteLine();


                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        if (player.Gold >= swordShop.Cost)
                        {
                            player.Gold -= swordShop.Cost; // Снимаем золото за покупку
                            player.Attack = swordShop.Damage;
                            Console.WriteLine($"Вы купили {swordShop.Name} за {swordShop.Cost} золота.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ваши основные характеристики после покупки инвентаря: ");
                            Console.WriteLine($"Здоровье: {player.Health}, Атака : {player.Attack}, Золото : {player.Gold}, Броня : {player.Armor}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно золота, чтобы купить меч");
                        }
                        break;
                    case "2":
                        if (player.Gold >= shieldShop.Cost)
                        {
                            player.Gold -= shieldShop.Cost; // Снимаем золото за покупку
                            player.Armor += shieldShop.Armor;
                            Console.WriteLine($"Вы купили {shieldShop.Name} за {shieldShop.Cost} золота.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ваши основные характеристики после покупки инвентаря: ");
                            Console.WriteLine($"Здоровье: {player.Health}, Атака : {player.Attack}, Золото : {player.Gold}, Броня : {player.Armor}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно золота, чтобы купить щит");
                        }
                        break;
                    case "3":
                        if (player.Gold >= potionShop.Cost)
                        {
                            player.Gold -= potionShop.Cost; // Снимаем золото за покупку
                            player.Health += potionShop.HealthRestore;
                            Console.WriteLine($"Вы купили {potionShop.Name} за {potionShop.Cost} золота.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ваши основные характеристики после покупки инвентаря: ");
                            Console.WriteLine($"Здоровье: {player.Health}, Атака : {player.Attack}, Золото : {player.Gold}, Броня : {player.Armor}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно золота, чтобы купить зелье");
                        }
                        break;
                    case "4":
                        if (player.Gold >= axeShop.Cost)
                        {
                            player.Gold -= axeShop.Cost; // Снимаем золото за покупку
                            player.Attack = axeShop.Damage;
                            Console.WriteLine($"Вы купили {axeShop.Name} за {axeShop.Cost} золота.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ваши основные характеристики после покупки инвентаря: ");
                            Console.WriteLine($"Здоровье: {player.Health}, Атака : {player.Attack}, Золото : {player.Gold}, Броня : {player.Armor}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно золота, чтобы купить топор");
                        }
                        break;
                    case "5":
                        exitFromShop = true;
                        break;
                    default:
                        Console.WriteLine("Выберите действие из списка.");
                        break;
                }
            }
        }






    }
}

