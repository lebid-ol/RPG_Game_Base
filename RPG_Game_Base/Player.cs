namespace RPG_Game_Base;

public class Player : GeneralCharacter 
{
    public int Level { get; set; }
    public int Armor { get; set; }

    public Player (string name, int health, int attack, int gold, int armor, int experience, int level) : base (name, health, attack, gold, experience)
    {
        Level = level;
        Armor = armor;

    }
}
