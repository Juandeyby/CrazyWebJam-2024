using System;
using UnityEngine;
using UnityEngine.UI;

public class TamagotchiView : MonoBehaviour, ITamagotchiView
{
    ITamagotchiPresenter _tamagotchiPresenter;
    
    [SerializeField] private Image _hungerBar;
    [SerializeField] private Image _happinessBar;
    
    private void Start()
    {
        _tamagotchiPresenter = new TamagotchiPresenter(this);
        _tamagotchiPresenter.UpdateView();
    }

    public void UpdateHunger(int hunger)
    {
        _hungerBar.fillAmount = hunger / 100f;
    }

    public void UpdateHappiness(int happiness)
    {
        _happinessBar.fillAmount = happiness / 100f;
    }

    public void UpdateEnergy(int energy)
    {
        throw new NotImplementedException();
    }

    public void UpdateHygiene(int hygiene)
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        
    }
}
