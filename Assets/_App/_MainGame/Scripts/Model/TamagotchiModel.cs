using UnityEngine;

public class TamagotchiModel
{
    public float Satiety { get; set; }
    public float Happiness { get; set; }
    public float Energy { get; set; }
    public float Hygiene { get; set; }
    
    public TamagotchiModel()
    {
        Satiety = 50;
        Happiness = 50;
        Energy = 50;
        Hygiene = 50;
    }
}
