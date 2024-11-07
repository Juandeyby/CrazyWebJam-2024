using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfiguration", menuName = "Tamagotchi/ItemConfiguration")]
public class ItemConfiguration : ScriptableObject
{
    [SerializeField] private Item[] uiItems;
    [SerializeField] private Item[] gameItems;
    private Dictionary<string, Item> idToUiItem;
    private Dictionary<string, Item> idToGameItem;

    private void Awake()
    {
        idToUiItem = new Dictionary<string, Item>();
        idToGameItem = new Dictionary<string, Item>();
        foreach (var item in uiItems)
        {
            idToUiItem.Add(item.Id, item);
        }
        foreach (var item in gameItems)
        {
            idToGameItem.Add(item.Id, item);
        }
    }
    
    public Item GetUiItemById(string id)
    {
        if (idToUiItem.TryGetValue(id, out var item))
        {
            return item;
        }
        throw new Exception($"Item with id {id} not found");
    }
    
    public Item GetGameItemById(string id)
    {
        if (idToGameItem.TryGetValue(id, out var item))
        {
            return item;
        }
        throw new Exception($"Item with id {id} not found");
    }
}
