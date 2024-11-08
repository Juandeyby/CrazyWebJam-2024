using CrazyGames;
using UnityEngine;

public class SaveSystem
{
    private readonly string Tamagotchi = "Tamagotchi";
    public TamagotchiModel LoadTamagotchi()
    {
        if (HasPlayedBefore() == false)
        {
            return new TamagotchiModel();
        }
        return LoadTamagotchiFromJson();
    }
    
    public void SaveTamagotchi(TamagotchiModel tamagotchiModel)
    {
        var json = JsonUtility.ToJson(tamagotchiModel);
#if UNITY_EDITOR
        PlayerPrefs.SetString(Tamagotchi, json);
#else
        CrazySDK.Data.SetString(Tamagotchi, json);
#endif
    }
    
    public TamagotchiModel LoadTamagotchiFromJson()
    {
#if UNITY_EDITOR
        var json = PlayerPrefs.GetString(Tamagotchi);
#else
        var json = CrazySDK.Data.GetString(Tamagotchi);
#endif
        return JsonUtility.FromJson<TamagotchiModel>(json);
    }
    
    public int LoadTime()
    {
#if UNITY_EDITOR
        return PlayerPrefs.GetInt("Time");
#else
        return CrazySDK.Data.GetInt("Time");
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
    
    public bool HasPlayedBefore()
    {
#if UNITY_EDITOR
        return PlayerPrefs.HasKey(Tamagotchi);
#else
        return CrazySDK.Data.HasKey(Tamagotchi);
#endif
    }
    
    public void DeleteAll()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#else
        CrazySDK.Data.DeleteAll();
#endif
    }
}
