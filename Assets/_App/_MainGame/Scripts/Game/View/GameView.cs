using System;
using System.Collections;
using _App._MainGame.Scripts.Presenter;
using TMPro;
using UnityEngine;

namespace _App._MainGame.Scripts.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private TMP_Text timeText;
        
        IGamePresenter _gamePresenter;
        
        private Coroutine _timerCoroutine;
        
        public void SetPresenter(IGamePresenter gamePresenter)
        {
            _gamePresenter = gamePresenter;
        }
        
        public void UpdateTime(int time)
        {
            var hours = time / 3600;
            var minutes = time / 60;
            var seconds = time % 60;
            timeText.text = $"Time: {hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}