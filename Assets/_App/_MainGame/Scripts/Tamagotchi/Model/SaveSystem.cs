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
#if UNITY_EDITOR
        return PlayerPrefs.GetFloat("Satiety");
#else
        return CrazySDK.Data.GetFloat("Satiety");
#endif
    }
    
    public float LoadHappiness()
    {
#if UNITY_EDITOR
        return PlayerPrefs.GetFloat("Happiness");
#else
        return CrazySDK.Data.GetFloat("Happiness");
#endif
    }
    
    public float LoadEnergy()
    {
#if UNITY_EDITOR
        return PlayerPrefs.GetFloat("Energy");
#else
        return CrazySDK.Data.GetFloat("Energy");
#endif
    }
    
    public float LoadHygiene()
    {
#if UNITY_EDITOR
        return PlayerPrefs.GetFloat("Hygiene");
#else
        return CrazySDK.Data.GetFloat("Hygiene");
#endif
    }
    
    public int LoadTime()
    {
#if UNITY_EDITOR
        return PlayerPrefs.GetInt("Time");
#else
        return CrazySDK.Data.GetInt("Time");
#endif
    }
    
    public void SaveHunger(float hunger)
    {
#if UNITY_EDITOR
        PlayerPrefs.SetFloat("Satiety", hunger);
#else
        CrazySDK.Data.SetFloat("Satiety", hunger);
#endif
    }
    
    public void SaveHappiness(float happiness)
    {
#if UNITY_EDITOR
        PlayerPrefs.SetFloat("Happiness", happiness);
#else
        CrazySDK.Data.SetFloat("Happiness", happiness);
#endif
    }
    
    public void SaveEnergy(float energy)
    {
#if UNITY_EDITOR
        PlayerPrefs.SetFloat("Energy", energy);
#else
        CrazySDK.Data.SetFloat("Energy", energy);
#endif
    }  
    
    public void SaveHygiene(float hygiene)
    {
#if UNITY_EDITOR
        PlayerPrefs.SetFloat("Hygiene", hygiene);
#else
        CrazySDK.Data.SetFloat("Hygiene", hygiene);
#endif
    }
    
    public void SaveTime(int time)
    {
#if UNITY_EDITOR
        PlayerPrefs.SetInt("Time", time);
#else
        CrazySDK.Data.SetInt("Time", time);
#endif
    }

    private bool HasPlayedBefore()
    {
#if UNITY_EDITOR
        return PlayerPrefs.HasKey("Satiety");
#else
        return CrazySDK.Data.HasKey("Satiety");
#endif
    }
    
    public void DeleteAll()
    {
        CrazySDK.Data.DeleteAll();
    }
}
