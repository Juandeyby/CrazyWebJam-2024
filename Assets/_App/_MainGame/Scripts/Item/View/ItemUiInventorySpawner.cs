using System.Collections.Generic;
using _App._MainGame.Scripts.Item.View;
using UnityEngine;

public class ItemUiInventorySpawner : MonoBehaviour, IItemUiInventorySpawner
{
    private ITamagotchiPresenter _tamagotchiPresenter;
    
    [Header("Config")]
    [SerializeField] private ItemConfiguration itemConfiguration;
    private ItemFactory _itemFactory;
    
    [Header("Creation")]
    [SerializeField] private Transform _itemContent;
    [SerializeField] private List<ItemId> _itemIds;

    private void Awake()
    {
        _itemFactory = new ItemFactory(Instantiate(itemConfiguration));
    }
    public void SetPresenter(TamagotchiPresenter tamagotchiPresenter)
    {
        _tamagotchiPresenter = tamagotchiPresenter;
    }
    
    private void SpawnItem(string id)
    {
        _tamagotchiPresenter.SpawnItem(id);
    }
 
    private void SpawnButton(string id, int amount)
    {
        var item = _itemFactory.CreateItemUiInventory(id, _itemContent);
        var itemUiInventory = item.GetComponent<ItemInventoryButton>();
        itemUiInventory.SetPresenter(_tamagotchiPresenter);
        itemUiInventory.AddListener(() => SpawnItem(id));
        itemUiInventory.SetAmount(amount);
    }
    
    private void Clean()
    {
        foreach (Transform child in _itemContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void UpdateInventory(ItemModel[] items)
    {
        Clean();
        foreach (var item in items)
        {
            SpawnButton(item.Id, item.Amount);
        }
    }
}
