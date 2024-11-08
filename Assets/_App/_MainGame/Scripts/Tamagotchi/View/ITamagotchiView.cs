using UnityEngine;

public interface ITamagotchiView
{
   void UpdateSatiety(float satiety);
   void UpdateHappiness(float happiness);
   void UpdateEnergy(float energy);
   void UpdateHygiene(float hygiene);
   void UpdateCoins(int coins);
   void UpdateInventory(ItemModel[] items);
   
   void BuyItem(ItemId itemId);
   void ConsumeItem(ItemId itemId);
}
