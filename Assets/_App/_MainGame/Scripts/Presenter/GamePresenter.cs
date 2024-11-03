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
        }
    }
}