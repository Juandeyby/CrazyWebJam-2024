using System;
using Lean.Gui;
using UnityEngine;

public class ItemStoreButton : MonoBehaviour
{
    private LeanButton _button;
    private Item _item;

    private void Awake()
    {
        _button = GetComponent<LeanButton>();
        _item = GetComponent<Item>();
        _button.OnClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        GameManager.Instance.TamagotchiView.BuyItem(_item.ItemId);
    }
    
    public void SetAvailability(bool isAvailable)
    {
        _button.interactable = isAvailable;
    }
}
