namespace RPG_Game_Base;

internal class Player : IGlobalCharacter 
{
    public string Name { get; set; }
    public double Health { get; set; }
    public double Attack { get; set; }
    public int Gold { get; set; }
    public int Experience { get; set; }
    public int AmountOfExperience { get; set; }
    public int Level { get; set; }

    internal Player (string name, double health, double attack, int gold, int experience, int amountOfExperience, int level)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Gold = gold;
        Experience = experience;
        AmountOfExperience = amountOfExperience;
        Level = level;

    }

    public void UseItem()
    {
        
    }
}
