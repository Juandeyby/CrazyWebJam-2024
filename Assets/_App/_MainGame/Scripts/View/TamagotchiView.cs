using System;
using UnityEngine;

public class TamagotchiView : MonoBehaviour, ITamagotchiView
{
    ITamagotchiPresenter _tamagotchiPresenter;
    
    private void Start()
    {
        _tamagotchiPresenter = new TamagotchiPresenter(this);
    }

    public void UpdateHunger(int hunger)
    {
        throw new NotImplementedException();
    }

    public void UpdateHappiness(int happiness)
    {
        throw new NotImplementedException();
    }

    public void UpdateEnergy(int energy)
    {
        throw new NotImplementedException();
    }

    public void UpdateHygiene(int hygiene)
    {
        throw new NotImplementedException();
    }
}
