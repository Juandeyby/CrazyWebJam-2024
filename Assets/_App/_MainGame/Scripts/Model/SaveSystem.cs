using CrazyGames;
using UnityEngine;

public class SaveSystem
{
    public TamagotchiModel LoadTamagotchi()
    {
        var tamagotchiModel = new TamagotchiModel();
        if (HasPlayedBefore() == false)
        {
            tamagotchiModel.Satiety = 50;
            tamagotchiModel.Happiness = 50;
            tamagotchiModel.Energy = 50;
            tamagotchiModel.Hygiene = 50;
            return tamagotchiModel;
        }
        tamagotchiModel.Satiety = LoadHunger();
        tamagotchiModel.Happiness = LoadHappiness();
        tamagotchiModel.Energy = LoadEnergy();
        tamagotchiModel.Hygiene = LoadHygiene();
        return tamagotchiModel;
    }
    
    public float LoadHunger()
    {
        return CrazySDK.Data.GetFloat("Satiety");
    }
    
    public float LoadHappiness()
    {
        return CrazySDK.Data.GetFloat("Happiness");
    }
    
    public float LoadEnergy()
    {
        return CrazySDK.Data.GetFloat("Energy");
    }
    
    public float LoadHygiene()
    {
        return CrazySDK.Data.GetFloat("Hygiene");
    }
    
    public float LoadTime()
    {
        return CrazySDK.Data.GetInt("Time");
    }
    
    public void SaveHunger(float hunger)
    {
        CrazySDK.Data.SetFloat("Satiety", hunger);
    }
    
    public void SaveHappiness(float happiness)
    {
        CrazySDK.Data.SetFloat("Happiness", happiness);
    }
    
    public void SaveEnergy(float energy)
    {
        CrazySDK.Data.SetFloat("Energy", energy);
    }  
    
    public void SaveHygiene(float hygiene)
    {
        CrazySDK.Data.SetFloat("Hygiene", hygiene);
    }
    
    public void SaveTime(int time)
    {
        CrazySDK.Data.SetInt("Time", time);
    }
    
    public bool HasPlayedBefore()
    {
        return CrazySDK.Data.HasKey("Satiety");
    }
    
    public void DeleteAll()
    {
        CrazySDK.Data.DeleteAll();
    }
}
