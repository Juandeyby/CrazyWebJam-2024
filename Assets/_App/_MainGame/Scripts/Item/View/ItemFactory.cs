using UnityEngine;

public class ItemFactory
{
    private readonly ItemConfiguration _itemConfiguration;
    
    public ItemFactory(ItemConfiguration itemConfiguration)
    {
        _itemConfiguration = itemConfiguration;
    }
    
    public Item CreateUiItem(string id, Transform content)
    {
        var prefab = _itemConfiguration.GetUiItemById(id);
        var item = Object.Instantiate(prefab, content);
        return item;
    }
    
    public Item CreateGameItem(string id, Transform content)
    {
        var prefab = _itemConfiguration.GetGameItemById(id);
        var item = Object.Instantiate(prefab, content);
        return item;
    }
}
