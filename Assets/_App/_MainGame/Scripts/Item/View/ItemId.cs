using UnityEngine;

[CreateAssetMenu(fileName = "ItemId", menuName = "Factory/Create ItemId")]
public class ItemId : ScriptableObject
{
    [SerializeField] private string _value;
    public string Value => _value;
}
