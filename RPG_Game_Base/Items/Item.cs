namespace RPG_Game_Base;

public class Item
{
        public string Name { get; set; } // Имя предмета 
        public int Cost { get; set; }  // Цена предмета
        public string Type { get; set; } // Тип предмета (например, "Оружие", "Броня" или "Зелье")
        public int Damage { get; set; } // Урон 
        public int Armor { get; set; } // Броня
        public int HealthRestore { get; set; } // Восстановление здоровья 

        
        public Item(string name, int cost, string type, int damage = 0, int armor = 0, int healthRestore = 0)
        {
            Name = name;
            Cost = cost;
            Type = type;
            Damage = damage;
            Armor = armor;
            HealthRestore = healthRestore;
        }

        // Метод для отображения информации о предмете
        public void DisplayInventory()
        {
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine($"Название: {Name}, Цена: {Cost}, Тип: {Type}");
        if (Damage > 0)
        {
            Console.WriteLine($"Урон: {Damage}");
        }
        if (Armor > 0)
        {
            Console.WriteLine($"Защита: {Armor}");
        }
        if (HealthRestore > 0)
        {
            Console.WriteLine($"Восстановление здоровья: {HealthRestore}");
        }
        Console.ResetColor();
    }
    }
