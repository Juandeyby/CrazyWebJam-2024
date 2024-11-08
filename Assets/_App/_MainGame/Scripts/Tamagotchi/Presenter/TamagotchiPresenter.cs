using _App._MainGame.Scripts.Item.Presenter;
using _App._MainGame.Scripts.Item.View;
using UnityEngine;

public class TamagotchiPresenter : ITamagotchiPresenter
{
    private TamagotchiModel _tamagotchiModel;
    private ITamagotchiView _tamagotchiView;
    private IItemUiStoreSpawner _itemUiStoreSpawner;
    private SaveSystem _saveSystem;
    
    public TamagotchiPresenter(SaveSystem saveSystem, ITamagotchiView tamagotchiView,
        TamagotchiModel tamagotchiModel, IItemUiStoreSpawner itemUiStoreSpawner)
    {
        _tamagotchiModel = tamagotchiModel;
        _saveSystem = saveSystem;
        _tamagotchiView = tamagotchiView;
        _itemUiStoreSpawner = itemUiStoreSpawner;
        
        TimerService.Instance.OnTimePerSecond += UpdateAttributes;
        Load();
    }
    
    private void UpdateAttributes()
    {
        UpdateSatiety(0.1f);
        UpdateHappiness(0.07f);
        UpdateEnergy(0.04f);
        UpdateHygiene(0.1f);
    }
    
    private void Load()
    {
        UpdateAttributesView();
        UpdateMarketView();
    }
    
    private void UpdateAttributesView()
    {
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }
    
    private void UpdateMarketView()
    {
        _tamagotchiView.UpdateCoins(_tamagotchiModel.Coins);
        _tamagotchiView.UpdateInventory(_tamagotchiModel.Items.ToArray());
        _itemUiStoreSpawner.UpdateStore();
    }
    
    public void Feed(float amount)
    {
        _tamagotchiModel.Satiety += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
    }

    public void Play(float amount)
    {
        _tamagotchiModel.Happiness += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
    }

    public void Sleep(float amount)
    {
        _tamagotchiModel.Energy += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
    }

    public void Clean(float amount)
    {
        _tamagotchiModel.Hygiene += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }

    public bool BuyItem(string itemId, int price)
    {
        if (!CanBuy(price)) return false;
        SpendCoins(price);
        _tamagotchiModel.AddItem(itemId);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateCoins(_tamagotchiModel.Coins);
        _tamagotchiView.UpdateInventory(_tamagotchiModel.Items.ToArray());
        _itemUiStoreSpawner.UpdateStore();
        return true;
    }
    
    private bool CanBuy(int price)
    {
        return _tamagotchiModel.Coins >= price;
    }
    
    private void SpendCoins(int price)
    {
        _tamagotchiModel.Coins -= price;
    }
    
    public void SpawnItem(string itemId)
    {
        _tamagotchiModel.RemoveItem(itemId);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateInventory(_tamagotchiModel.Items.ToArray());
    }
    
    public void UpdateSatiety(float satiety, int time = 1)
    {
        var satietyValue = _tamagotchiModel.Satiety - satiety * time;
        _tamagotchiModel.Satiety = Mathf.Clamp(satietyValue, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
    }

    public void UpdateHappiness(float happiness, int time = 1)
    {
        var happinessValue = _tamagotchiModel.Happiness - happiness * time;
        _tamagotchiModel.Happiness = Mathf.Clamp(happinessValue, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
    }

    public void UpdateEnergy(float energy, int time = 1)
    {
        var energyValue = _tamagotchiModel.Energy - energy * time;
        _tamagotchiModel.Energy = Mathf.Clamp(energyValue, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
    }

    public void UpdateHygiene(float hygiene, int time = 1)
    {
        var hygieneValue = _tamagotchiModel.Hygiene - hygiene * time;
        _tamagotchiModel.Hygiene = Mathf.Clamp(hygieneValue, 0, 100);
        _saveSystem.SaveTamagotchi(_tamagotchiModel);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }

    public void UpdateCoins(int coins)
    {
        _tamagotchiView.UpdateCoins(coins);
    }

    public void UpdateItems(ItemModel[] items)
    {
        _tamagotchiView.UpdateInventory(items);
    }

    public void Dispose()
    {
        TimerService.Instance.OnTimePerSecond -= UpdateAttributes;
    }

}
