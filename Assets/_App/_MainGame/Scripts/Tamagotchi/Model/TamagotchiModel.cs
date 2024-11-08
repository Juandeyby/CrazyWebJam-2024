using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TamagotchiModel
{
    public float Satiety;
    public float Happiness;
    public float Energy;
    public float Hygiene;
    public int Coins;
    public List<ItemModel> Items;
    
    public TamagotchiModel()
    {
        Satiety = 50;
        Happiness = 50;
        Energy = 50;
        Hygiene = 50;
        Coins = 1000;
        Items = new List<ItemModel>();
    }
    
    public void AddItem(string itemId)
    {
        if (Items.Exists(i => i.Id == itemId))
        {
            var itemModel = Items.Find(i => i.Id == itemId);
            itemModel.Amount++;
        }
        else
        {
            var item = new ItemModel {Id = itemId, Amount = 1};
            Items.Add(item);
        }
    }
 
    public void RemoveItem(string itemId)
    {
        if (Items.Exists(i => i.Id == itemId))
        {
            var itemModel = Items.Find(i => i.Id == itemId);
            itemModel.Amount--;
            if (itemModel.Amount <= 0)
            {
                Items.Remove(itemModel);
            }
        }
    }
}
