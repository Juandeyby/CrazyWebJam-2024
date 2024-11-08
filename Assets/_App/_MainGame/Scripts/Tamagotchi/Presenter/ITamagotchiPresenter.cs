using UnityEngine;

public interface ITamagotchiPresenter
{
    void Feed(ItemId itemId);
    void Play(ItemId itemId);
    void Sleep(ItemId itemId);
    void Clean(ItemId itemId);
    bool BuyItem(string itemId, int price);
    void SpawnItem(string itemId);
    void ConsumeItem(ItemId itemId);
    
    void UpdateSatiety(float satiety, int time);
    void UpdateHappiness(float happiness, int time);
    void UpdateEnergy(float energy, int time);
    void UpdateHygiene(float hygiene, int time);
    void UpdateCoins(int coins);
    void UpdateItems(ItemModel[] items);
}
