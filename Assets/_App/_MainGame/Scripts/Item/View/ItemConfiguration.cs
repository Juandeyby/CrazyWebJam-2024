using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemConfiguration", menuName = "Tamagotchi/ItemConfiguration")]
public class ItemConfiguration : ScriptableObject
{
    [FormerlySerializedAs("uiItems")] [SerializeField] private Item[] itemUiStore;
    [SerializeField] private Item[] itemUiInventory;
    [FormerlySerializedAs("gameItems")] [SerializeField] private Item[] itemGame;
    private Dictionary<string, Item> _idToUiItem;
    private Dictionary<string, Item> _idToGameItem;
    private Dictionary<string, Item> _idToUiInventoryItem;

    private void Awake()
    {
        _idToUiItem = new Dictionary<string, Item>();
        _idToGameItem = new Dictionary<string, Item>();
        _idToUiInventoryItem = new Dictionary<string, Item>();
        foreach (var item in itemUiStore)
        {
            _idToUiItem.Add(item.Id, item);
        }
        foreach (var item in itemGame)
        {
            _idToGameItem.Add(item.Id, item);
        }
        foreach (var item in itemUiInventory)
        {
            _idToUiInventoryItem.Add(item.Id, item);
        }
    }
    
    public Item GetItemUiStoreById(string id)
    {
        if (_idToUiItem.TryGetValue(id, out var item))
        {
            return item;
        }
        throw new Exception($"Item with id {id} not found");
    }
    
    public Item GetItemGameById(string id)
    {
        if (_idToGameItem.TryGetValue(id, out var item))
        {
            return item;
        }
        throw new Exception($"Item with id {id} not found");
    }
    
    public Item GetItemUiInventoryById(string id)
    {
        if (_idToUiInventoryItem.TryGetValue(id, out var item))
        {
            return item;
        }
        throw new Exception($"Item with id {id} not found");
    }
}
