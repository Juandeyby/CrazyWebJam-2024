using UnityEngine;

public class TamagotchiPresenter : ITamagotchiPresenter
{
    private TamagotchiModel _tamagotchiModel;
    private ITamagotchiView _tamagotchiView;
    
    public TamagotchiPresenter(ITamagotchiView tamagotchiView)
    {
        _tamagotchiModel = new TamagotchiModel();
        _tamagotchiView = tamagotchiView;
    }
    
    public void Feed(int amount)
    {
        _tamagotchiModel.Hunger += Mathf.Clamp(amount, 0, 100);
        _tamagotchiView.UpdateHunger(_tamagotchiModel.Hunger);
    }

    public void Play(int amount)
    {
        _tamagotchiModel.Happiness += Mathf.Clamp(amount, 0, 100);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
    }

    public void Sleep(int amount)
    {
        _tamagotchiModel.Energy += Mathf.Clamp(amount, 0, 100);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
    }

    public void Clean(int amount)
    {
        _tamagotchiModel.Hygiene += Mathf.Clamp(amount, 0, 100);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }
}
