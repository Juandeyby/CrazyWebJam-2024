using System.Collections.Generic;
using UnityEngine;

public class TamagotchiModel
{
    public float Satiety { get; set; }
    public float Happiness { get; set; }
    public float Energy { get; set; }
    public float Hygiene { get; set; }
    public int Coins { get; set; }
    public List<Item> Items { get; set; }
    
    public TamagotchiModel()
    {
        Satiety = 50;
        Happiness = 50;
        Energy = 50;
        Hygiene = 50;
        Coins = 100;
        Items = new List<Item>();
    }
    
    public void AddItem(Item item)
    {
        Items.Add(item);
    }
}
