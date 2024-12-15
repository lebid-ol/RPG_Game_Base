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
        public void BuyItem(Player player, Item item)
        {
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (player.Gold >= item.Cost)
                    {
                        player.Gold -= item.Cost; // Снимаем золото за покупку
                        Console.WriteLine($"Вы купили {item.Name} за {item.Cost} золота.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота для покупки!");
                    }
                    break;
                case "2":
                   
                    break;
                case "3":
                  
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Выберите действие из списка.");
                    break;
            }
            // Проверяем, есть ли у игрока достаточно золота для покупки
            if (player.Gold >= item.Cost)
            {
                player.Gold -= item.Cost; // Снимаем золото за покупку
                Console.WriteLine($"Вы купили {item.Name} за {item.Cost} золота.");
            }
            else
            {
                Console.WriteLine("Недостаточно золота для покупки!");
            }
        }






    }
}

