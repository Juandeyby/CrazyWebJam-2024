using UnityEngine;

public class TamagotchiPresenter : ITamagotchiPresenter
{
    private TamagotchiModel _tamagotchiModel;
    private ITamagotchiView _tamagotchiView;
    private SaveSystem _saveSystem;
    
    public TamagotchiPresenter(SaveSystem saveSystem, ITamagotchiView tamagotchiView, TamagotchiModel tamagotchiModel)
    {
        _tamagotchiModel = tamagotchiModel;
        _saveSystem = saveSystem;
        _tamagotchiView = tamagotchiView;
        
        TimerService.Instance.OnTimePerSecond += UpdateAttributes;
    }
    
    private void UpdateAttributes()
    {
        UpdateSatiety(0.1f);
        UpdateHappiness(0.07f);
        UpdateEnergy(0.04f);
        UpdateHygiene(0.1f);
        UpdateView();
    }
    
    private void UpdateView()
    {
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }
    
    public void Feed(float amount)
    {
        _tamagotchiModel.Satiety += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveHunger(_tamagotchiModel.Satiety);
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
    }

    public void Play(float amount)
    {
        _tamagotchiModel.Happiness += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveHappiness(_tamagotchiModel.Happiness);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
    }

    public void Sleep(float amount)
    {
        _tamagotchiModel.Energy += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveEnergy(_tamagotchiModel.Energy);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
    }

    public void Clean(float amount)
    {
        _tamagotchiModel.Hygiene += Mathf.Clamp(amount, 0, 100);
        _saveSystem.SaveHygiene(_tamagotchiModel.Hygiene);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }

    public void UpdateSatiety(float satiety, int time = 1)
    {
        var satietyValue = _tamagotchiModel.Satiety - satiety * time;
        _tamagotchiModel.Satiety = Mathf.Clamp(satietyValue, 0, 100);
        _saveSystem.SaveHunger(_tamagotchiModel.Satiety);
        _tamagotchiView.UpdateSatiety(_tamagotchiModel.Satiety);
    }

    public void UpdateHappiness(float happiness, int time = 1)
    {
        var happinessValue = _tamagotchiModel.Happiness - happiness * time;
        _tamagotchiModel.Happiness = Mathf.Clamp(happinessValue, 0, 100);
        _saveSystem.SaveHappiness(_tamagotchiModel.Happiness);
        _tamagotchiView.UpdateHappiness(_tamagotchiModel.Happiness);
    }

    public void UpdateEnergy(float energy, int time = 1)
    {
        var energyValue = _tamagotchiModel.Energy - energy * time;
        _tamagotchiModel.Energy = Mathf.Clamp(energyValue, 0, 100);
        _saveSystem.SaveEnergy(_tamagotchiModel.Energy);
        _tamagotchiView.UpdateEnergy(_tamagotchiModel.Energy);
    }

    public void UpdateHygiene(float hygiene, int time = 1)
    {
        var hygieneValue = _tamagotchiModel.Hygiene - hygiene * time;
        _tamagotchiModel.Hygiene = Mathf.Clamp(hygieneValue, 0, 100);
        _saveSystem.SaveHygiene(_tamagotchiModel.Hygiene);
        _tamagotchiView.UpdateHygiene(_tamagotchiModel.Hygiene);
    }

    public void Load()
    {
        _tamagotchiModel = _saveSystem.LoadTamagotchi();
        UpdateView();
    }
    
    public void Dispose()
    {
        TimerService.Instance.OnTimePerSecond -= UpdateAttributes;
    }
}
