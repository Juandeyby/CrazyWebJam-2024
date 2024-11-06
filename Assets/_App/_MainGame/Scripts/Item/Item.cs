using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected string id;
    public string Id => id;
}
