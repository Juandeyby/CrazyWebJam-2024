using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfiguration", menuName = "Tamagotchi/ItemConfiguration")]
public class ItemConfiguration : ScriptableObject
{
    [SerializeField] private Item[] items;
    private Dictionary<string, Item> idToItem;

    private void Awake()
    {
        idToItem = new Dictionary<string, Item>(items.Length);
        foreach (var item in items)
        {
            idToItem.Add(item.Id, item);
        }
    }
    
    public Item GetItemById(string id)
    {
        if (idToItem.TryGetValue(id, out var item))
        {
            return item;
        }
        else
        {
            throw new ArgumentException($"Item with id {id} not found");
        }
    }
}
