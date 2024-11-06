using UnityEngine;

public class ItemSpawner
{
    private readonly ItemFactory _itemFactory;
    
    public ItemSpawner(ItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }
    
    public void SpawnItem(string id)
    {
        var item = _itemFactory.CreateItem(id);
        item.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
