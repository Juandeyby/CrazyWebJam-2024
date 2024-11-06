using UnityEngine;

public class ItemFactory
{
    private readonly ItemConfiguration _itemConfiguration;
    
    public ItemFactory(ItemConfiguration itemConfiguration)
    {
        _itemConfiguration = itemConfiguration;
    }
    
    public Item CreateItem(string id)
    {
        var prefab = _itemConfiguration.GetItemById(id);
        return Object.Instantiate(prefab);
    }
}
