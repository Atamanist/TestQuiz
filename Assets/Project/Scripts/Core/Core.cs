using System;
using System.Collections.Generic;
using Project.Game.Controller;
using Project.Game.Model;
using Project.Game.View;
using Project.Level.Controller;
using Project.Level.View;
using UnityEngine;

namespace Project.Core
{
    public class Core : MonoBehaviour
    {
        [SerializeField] private GameConfigData _config;

        [SerializeField] private LevelView _levelView;
        [SerializeField] private GameView _gameView;

        [SerializeField] private ErrorWindow _error;

        private ParserSystem _parserSystem;

        private GameController _gameController;
        private GameModel _gameModel;
        private LevelController _levelController;

        private void Start()
        {
            Controllers();
            CreateGame();
            if (_gameModel != null)
            {
                InitGame();
            }
        }

        private void Controllers()
        {
            _parserSystem = new ParserSystem();
            _gameController = new GameController();
            _levelController = new LevelController();
        }

        private void CreateGame()
        {
            List<string> words = new List<string>();
            try
            {
                words = _parserSystem.Parse(_config.Path, _config.Lenght);
                if (words.Count <= 0)
                {
                    throw new Exception(message: "no words");
                }

                _gameModel = new GameModel()
                {
                    AvailableLives = _config.Lives,
                    BaseLives = _config.Lives,
                    AvailableWords = new List<string>(words),
                    BaseWords = new List<string>(words),
                    AvailableLetters = _config.Letters
                };
            }
            catch (Exception e)
            {
                _error.Show(e.Message);
                _error.gameObject.SetActive(true);
            }
        }

        private void InitGame()
        {
            _gameController.Init(_gameView, _gameModel);
            _levelController.Init(_levelView);
            Sub();
            _gameController.StartGame();
        }

        private void Sub()
        {
            _gameController.StartLevel = _levelController.CreatLevel;
            _levelController.LevelEnd = _gameController.GameCondition;
        }
    }
}