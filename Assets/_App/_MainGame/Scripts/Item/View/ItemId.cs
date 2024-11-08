using UnityEngine;

[CreateAssetMenu(fileName = "ItemId", menuName = "Factory/Create ItemId")]
public class ItemId : ScriptableObject
{
    [SerializeField] private string _value;
    public string Value => _value;
    
    [SerializeField] private int _price;
    public int Price => _price;
    
    [SerializeField] private string _name;
    public string Name => _name;
 
    [SerializeField] private ItemType _type;
    public ItemType Type => _type;
}

public enum ItemType
{
    Food,
    Toys,
    Hygiene
}
