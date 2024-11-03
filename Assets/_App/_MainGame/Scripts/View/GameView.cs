using System;
using System.Collections;
using _App._MainGame.Scripts.Presenter;
using UnityEngine;

namespace _App._MainGame.Scripts.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        IGamePresenter _gamePresenter;
        
        private Coroutine _timerCoroutine;
        
        public void SetPresenter(IGamePresenter gamePresenter)
        {
            _gamePresenter = gamePresenter;
        }
        
        public void UpdateTime(int time)
        {
            Debug.Log("Time: " + time);
        }
    }
}