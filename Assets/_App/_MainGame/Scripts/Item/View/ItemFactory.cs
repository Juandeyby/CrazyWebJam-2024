using UnityEngine;

public class ItemFactory
{
    private readonly ItemConfiguration _itemConfiguration;
    
    public ItemFactory(ItemConfiguration itemConfiguration)
    {
        _itemConfiguration = itemConfiguration;
    }
    
    public Item CreateItemUiStore(string id, Transform content)
    {
        var prefab = _itemConfiguration.GetItemUiStoreById(id);
        var item = Object.Instantiate(prefab, content);
        return item;
    }
    
    public Item CreateItemGame(string id, Transform parent)
    {
        var prefab = _itemConfiguration.GetItemGameById(id);
        var item = Object.Instantiate(prefab, parent);
        return item;
    }
    
    public Item CreateItemUiInventory(string id, Transform content)
    {
        var prefab = _itemConfiguration.GetItemUiInventoryById(id);
        var item = Object.Instantiate(prefab, content);
        return item;
    }
}
