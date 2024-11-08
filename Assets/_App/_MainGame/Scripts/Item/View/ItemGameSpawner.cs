using System.Collections.Generic;
using UnityEngine;

public class ItemGameSpawner : MonoBehaviour
{
    public static ItemGameSpawner Instance { get; private set; }
    
    [Header("Config")]
    [SerializeField] private ItemConfiguration itemConfiguration;
    private ItemFactory _itemFactory;
    
    [Header("Creation")]
    [SerializeField] private List<ItemId> _itemIds;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _itemFactory = new ItemFactory(Instantiate(itemConfiguration));
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SpawnGameItem(string id)
    {
        var item = _itemFactory.CreateItemGame(id, transform);
        item.transform.localPosition = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
    }
}
