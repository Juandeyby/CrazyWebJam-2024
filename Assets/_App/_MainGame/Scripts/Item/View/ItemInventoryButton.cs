using System;
using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _itemAmountText;
    
    private LeanButton _button;
    private Item _item;
    private ITamagotchiPresenter _tamagotchiPresenter;

    private void Awake()
    {
        _button = GetComponent<LeanButton>();
        _item = GetComponent<Item>();
        _button.OnClick.AddListener(OnButtonClick);
        
        SetItem(_item.ItemId);
    }

    private void OnButtonClick()
    {
        ItemGameSpawner.Instance.SpawnGameItem(_item.Id);
    }
    
    public void SetAmount(int amount)
    {
        _itemAmountText.text = amount.ToString();
    }
    
    public void SetPresenter(ITamagotchiPresenter tamagotchiPresenter)
    {
        _tamagotchiPresenter = tamagotchiPresenter;
    }
    
    public void AddListener(UnityAction action)
    {
        _button.OnClick.AddListener(action);
    }
    
    private void SetItem(ItemId itemId)
    {
        _icon = itemId.Icon;
        _nameText.text = itemId.Name;
    }
}
