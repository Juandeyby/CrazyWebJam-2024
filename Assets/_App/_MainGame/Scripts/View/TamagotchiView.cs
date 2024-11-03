using System;
using UnityEngine;
using UnityEngine.UI;

public class TamagotchiView : MonoBehaviour, ITamagotchiView
{
    ITamagotchiPresenter _tamagotchiPresenter;
    SaveSystem _saveSystem;
    
    [SerializeField] private Image _satietyBar;
    [SerializeField] private Image _happinessBar;
    [SerializeField] private Image _energyBar;
    [SerializeField] private Image _hygieneBar;
    
    public void SetPresenter(ITamagotchiPresenter presenter)
    {
        _tamagotchiPresenter = presenter;
    }

    #region <<Events trigger presenter methods>>
    public void UpdateSatiety(float amount)
    {
        _satietyBar.fillAmount = amount / 100f;
    }

    public void UpdateHappiness(float happiness)
    {
        _happinessBar.fillAmount = happiness / 100f;
    }

    public void UpdateEnergy(float energy)
    {
        _energyBar.fillAmount = energy / 100f;
    }

    public void UpdateHygiene(float hygiene)
    {
        _hygieneBar.fillAmount = hygiene / 100f;
    }
    #endregion

    #region <<View methods trigger calls them>>

    
    
    #endregion

    private void Update()
    {
        
    }
}
