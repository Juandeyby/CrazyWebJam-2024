using System;
using _App._MainGame.Scripts.Presenter;
using _App._MainGame.Scripts.View;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private TamagotchiPresenter _tamagotchiPresenter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        var saveSystem = new SaveSystem();
        
        var tamagotchiModel = new TamagotchiModel();
        var tamagotchiView = FindFirstObjectByType<TamagotchiView>();
        _tamagotchiPresenter = new TamagotchiPresenter(saveSystem, tamagotchiView, tamagotchiModel);
        
        _tamagotchiPresenter.Load();
        tamagotchiView.SetPresenter(_tamagotchiPresenter);
        
        var gameModel = new GameModel();
        var gameView = FindFirstObjectByType<GameView>();
        var gamePresenter = new GamePresenter(saveSystem, gameView, gameModel);
        
        gameView.SetPresenter(gamePresenter);
    }

    private void OnDisable()
    {
        _tamagotchiPresenter.Dispose();
    }
}