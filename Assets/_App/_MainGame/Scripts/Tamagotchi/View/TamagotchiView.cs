using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TamagotchiView : MonoBehaviour, ITamagotchiView
{
    ITamagotchiPresenter _tamagotchiPresenter;
    SaveSystem _saveSystem;
    
    [Header("Bars")]
    [SerializeField] private Image _satietyBar;
    [SerializeField] private Image _happinessBar;
    [SerializeField] private Image _energyBar;
    [SerializeField] private Image _hygieneBar;
    
    [Header("Coins")]
    [SerializeField] private TMP_Text _coinsText;
    
    [Header("Inventory")]
    [SerializeField] private ItemUiInventorySpawner _itemUiInventorySpawner;
    
    public void SetPresenter(ITamagotchiPresenter presenter)
    {
        _tamagotchiPresenter = presenter;
    }

    #region <<Events trigger presenter methods>>
    public void UpdateSatiety(float amount)
    {
        _satietyBar.fillAmount = amount / 100f;
    }

    public void UpdateHappiness(float happiness)
    {
        _happinessBar.fillAmount = happiness / 100f;
    }

    public void UpdateEnergy(float energy)
    {
        _energyBar.fillAmount = energy / 100f;
    }

    public void UpdateHygiene(float hygiene)
    {
        _hygieneBar.fillAmount = hygiene / 100f;
    }

    public void UpdateCoins(int coins)
    {
        _coinsText.text = coins.ToString();
    }

    public void UpdateInventory(ItemModel[] items)
    {
        _itemUiInventorySpawner.UpdateInventory(items);
    }

    #endregion

    #region <<View methods trigger calls them>>

    public void BuyItem(ItemId itemId)
    {
        _tamagotchiPresenter.BuyItem(itemId.Value, itemId.Price);
    }
    
    public void ConsumeItem(ItemId itemId)
    {
        _tamagotchiPresenter.ConsumeItem(itemId);
    }
    
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            var item = other.GetComponent<Item>();
            if (item != null)
            {
                ConsumeItem(item.ItemId);
                Destroy(other.gameObject);
            }
        }
    }
}
