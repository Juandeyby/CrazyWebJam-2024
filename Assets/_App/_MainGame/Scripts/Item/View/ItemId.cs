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
    
    [SerializeField] private int _satiety;
    public int Satiety => _satiety;
    
    [SerializeField] private int _happiness;
    public int Happiness => _happiness;
    
    [SerializeField] private int _energy;
    public int Energy => _energy;
    
    [SerializeField] private int _hygiene;
    public int Hygiene => _hygiene;
    
    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
}

public enum ItemType
{
    Food,
    Toys,
    Hygiene
}
