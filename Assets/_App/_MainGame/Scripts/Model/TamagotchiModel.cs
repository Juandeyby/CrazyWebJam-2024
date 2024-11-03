using UnityEngine;

public class TamagotchiModel
{
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }
    public int Hygiene { get; set; }
    
    public TamagotchiModel()
    {
        Hunger = 50;
        Happiness = 50;
        Energy = 50;
        Hygiene = 50;
    }
}
