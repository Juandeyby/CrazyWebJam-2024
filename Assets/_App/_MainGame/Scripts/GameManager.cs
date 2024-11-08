using System;
using _App._MainGame.Scripts.Item.Presenter;
using _App._MainGame.Scripts.Presenter;
using _App._MainGame.Scripts.View;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private TamagotchiPresenter _tamagotchiPresenter;
    private TamagotchiView _tamagotchiView;
    public TamagotchiView TamagotchiView => _tamagotchiView;
    
    private GamePresenter _gamePresenter;

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
        
        var tamagotchiModel = saveSystem.LoadTamagotchi();
        
        var itemUiStoreSpawner = FindFirstObjectByType<ItemUiStoreSpawner>();
        var itemPresenter = new ItemPresenter(tamagotchiModel, itemUiStoreSpawner);
        itemUiStoreSpawner.SetPresenter(itemPresenter);
        
        _tamagotchiView = FindFirstObjectByType<TamagotchiView>();
        _tamagotchiPresenter = new TamagotchiPresenter(saveSystem, _tamagotchiView, tamagotchiModel, itemUiStoreSpawner);
        _tamagotchiView.SetPresenter(_tamagotchiPresenter);
        
        var itemUiInventorySpawner = FindFirstObjectByType<ItemUiInventorySpawner>();
        itemUiInventorySpawner.SetPresenter(_tamagotchiPresenter);
        
        var gameModel = new GameModel();
        var gameView = FindFirstObjectByType<GameView>();
        _gamePresenter = new GamePresenter(saveSystem, gameView, gameModel);
        gameView.SetPresenter(_gamePresenter);
    }

    private void OnDisable()
    {
        _tamagotchiPresenter.Dispose();
        _gamePresenter.Dispose();
    }
}
