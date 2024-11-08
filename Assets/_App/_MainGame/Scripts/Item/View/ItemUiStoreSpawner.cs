using System;
using System.Collections.Generic;
using _App._MainGame.Scripts.Item.Presenter;
using _App._MainGame.Scripts.Item.View;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemUiStoreSpawner : MonoBehaviour, IItemUiStoreSpawner
{
    [Header("Config")]
    [SerializeField] private ItemConfiguration itemConfiguration;
    private ItemFactory _itemFactory;
    
    [Header("Creation")]
    [SerializeField] private Transform _itemFoodContent;
    [SerializeField] private Transform _itemToysContent;
    [SerializeField] private Transform _itemHygieneContent;
    [SerializeField] private List<ItemId> _itemIds;
    
    private ItemPresenter _itemPresenter;

    private void Awake()
    {
        _itemFactory = new ItemFactory(Instantiate(itemConfiguration));
    }
    
    public void SetPresenter(ItemPresenter itemPresenter)
    {
        _itemPresenter = itemPresenter;
    }
    
    public void UpdateStore()
    {
        Clean();
        foreach (var itemId in _itemIds)
        {
            SpawnButton(itemId);
        }
    }

    public void SpawnButton(ItemId id)
    {
        switch (id.Type)
        {
            case ItemType.Food:
                SpawnItem(id, _itemFoodContent);
                break;
            case ItemType.Toys:
                SpawnItem(id, _itemToysContent);
                break;
            case ItemType.Hygiene:
                SpawnItem(id, _itemHygieneContent);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SpawnItem(ItemId itemId, Transform itemFoodContent)
    {
        var item = _itemFactory.CreateItemUiStore(itemId.Value, itemFoodContent);
        var itemUiStore = item.GetComponent<ItemStoreButton>();
        itemUiStore.SetAvailability(_itemPresenter.IsItemCanBuy(itemId));
    }
    
    private void Clean()
    {
        Clean(_itemFoodContent);
        Clean(_itemToysContent);
        Clean(_itemHygieneContent);
    }
    
    private void Clean(Transform content)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
