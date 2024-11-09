using System;
using Lean.Gui;
using TMPro;
using UnityEngine;

public class ItemStoreButton : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    private LeanButton _button;
    private Item _item;

    private void Awake()
    {
        _button = GetComponent<LeanButton>();
        _item = GetComponent<Item>();
        _button.OnClick.AddListener(OnButtonClick);
        
        SetItem(_item.ItemId);
    }

    private void OnButtonClick()
    {
        GameManager.Instance.TamagotchiView.BuyItem(_item.ItemId);
    }
    
    public void SetAvailability(bool isAvailable)
    {
        _button.interactable = isAvailable;
    }
    
    private void SetItem(ItemId itemId)
    {
        _icon = itemId.Icon;
        _nameText.text = itemId.Name;
        _priceText.text = itemId.Price.ToString();
    }
}
