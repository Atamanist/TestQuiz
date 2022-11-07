using System;
using System.Collections.Generic;
using Project.Game.Model;
using Project.Game.View;
using UnityEngine;

namespace Project.Game.Controller
{
    public class GameController
    {
        private GameModel _model;
        private GameView _view;

        public Action<string, int,string> StartLevel;

        public void Init(GameView view, GameModel model)
        {
            _view = view;
            _model = model;
        }

        public void GameCondition(string word, int lives)
        {
            string message = "";
            if (lives > 0)
            {
                _model.AvailableLives += lives;

                if (_model.AvailableWords.Count <= 0)
                {
                    message = $"You Win Score{_model.AvailableLives}";
                    _view.Show(message, RestartGame);
                    _view.gameObject.SetActive(true);
                }
                else
                {
                    message = "You win level";
                    _view.Show(message, NextLevel);
                    _view.gameObject.SetActive(true);
                }
            }

            else
            {
                message = "You Lose";
                _view.Show(message, RestartGame);
                _view.gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            _model.AvailableLives = _model.BaseLives;
            _model.AvailableWords =new List<string>(_model.BaseWords);
            _view.gameObject.SetActive(false);

            NextLevel();
        }

        private void NextLevel()
        {
            string random = _model.AvailableWords[UnityEngine.Random.Range(0, _model.AvailableWords.Count)];
            _model.AvailableWords.Remove(random);
            Debug.Log("Available words "+_model.AvailableWords.Count);
            _view.gameObject.SetActive(false);
            StartLevel?.Invoke(random, _model.AvailableLives,_model.AvailableLetters);
        }

        public void StartGame()
        {
            NextLevel();
        }
    }
}