using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemId _id;
    public string Id => _id.Value;
    public ItemId ItemId => _id;
}