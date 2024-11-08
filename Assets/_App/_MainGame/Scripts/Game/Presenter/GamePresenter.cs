using System;
using _App._MainGame.Scripts.View;
using UnityEngine;

namespace _App._MainGame.Scripts.Presenter
{
    public class GamePresenter : IGamePresenter
    {
        public event Action OnTimeUpdated;
        
        private GameModel _gameModel;
        private IGameView _gameView;
        private SaveSystem _saveSystem;
        
        public GamePresenter(SaveSystem saveSystem, IGameView gameView, GameModel gameModel)
        {
            _gameModel = gameModel;
            _saveSystem = saveSystem;
            _gameView = gameView;
            
            TimerService.Instance.OnTimePerSecond += UpdateTime;
            Load();
        }
        
        public void UpdateTime()
        {
            _gameModel.Time++;
            _saveSystem.SaveTime(_gameModel.Time);
            _gameView.UpdateTime(_gameModel.Time);
            OnTimeUpdated?.Invoke();
        }
        
        private void Load()
        {
            _gameModel.Time = _saveSystem.LoadTime();
            _gameView.UpdateTime(_gameModel.Time);
        }
        
        public void Dispose()
        {
            TimerService.Instance.OnTimePerSecond -= UpdateTime;
        }
    }
}