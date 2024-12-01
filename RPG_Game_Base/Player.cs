namespace RPG_Game_Base;

public class Player : GeneralCharacter 
{
    public int AmountOfExperience { get; set; }
    public int Level { get; set; }

    public Player (string name, int health, int attack, int gold, int experience, int amountOfExperience, int level) : base (name, health, attack, gold, experience)
    {
        AmountOfExperience = amountOfExperience;
        Level = level;

    }

    public void UseItem()
    {
        
    }
}
