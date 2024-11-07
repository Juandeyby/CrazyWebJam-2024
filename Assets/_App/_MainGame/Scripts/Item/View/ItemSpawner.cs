using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private ItemConfiguration itemConfiguration;
    private ItemFactory _itemFactory;
    
    [Header("Creation")]
    [SerializeField] private Transform _itemContent;
    [SerializeField] private List<ItemId> _itemIds;

    private void Awake()
    {
        _itemFactory = new ItemFactory(Instantiate(itemConfiguration));
    }

    private void Start()
    {
        foreach (var itemId in _itemIds)
        {
            SpawnUiItem(itemId.Value);
        }
    }

    public void SpawnUiItem(string id)
    {
        var item = _itemFactory.CreateUiItem(id, _itemContent);
//        item.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
