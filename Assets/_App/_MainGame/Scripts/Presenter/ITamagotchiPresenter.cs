using UnityEngine;

public interface ITamagotchiPresenter
{
    void Feed(float amount);
    void Play(float amount);
    void Sleep(float amount);
    void Clean(float amount);
    
    void UpdateSatiety(float satiety, int time);
    void UpdateHappiness(float happiness, int time);
    void UpdateEnergy(float energy, int time);
    void UpdateHygiene(float hygiene, int time);
    void Load();
}
