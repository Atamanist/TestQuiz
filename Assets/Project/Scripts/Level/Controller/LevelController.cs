using System;
using Project.Level.Model;
using Project.Level.View;
using UnityEngine;

namespace Project.Level.Controller
{
    public class LevelController
    {
        private LevelModel _model;
        private LevelView _view;

        public Action<string, int> LevelEnd;

        public void Init(LevelView view)
        {
            _view = view;
        }


        private void ShowView()
        {
            _view.Init(_model.CodeWord, _model.AvailableChars, _model.Lives, CheckLetter);
            _view.gameObject.SetActive(true);
        }

        private void CheckLetter(char letter)
        {
            if (_model.Word.Contains(letter))
            {
                char[] charsWord = _model.Word.ToCharArray();
                char[] charsCodeWord = _model.CodeWord.ToCharArray();

                for (int i = 0; i < charsWord.Length; i++)
                {
                    if (charsWord[i] == letter)
                    {
                        charsCodeWord[i] = letter;
                        _model.Score++;
                    }
                }

                string word = new string(charsCodeWord);
                _model.CodeWord = word;
            }
            else
            {
                _model.Lives--;
            }

            _view.ChangeText(_model.CodeWord, _model.Lives);

            CheckLevelCondition();
        }

        public void CreatLevel(string word, int lives, string availableLetters)
        {
            Debug.Log("Level word "+word);

            string codeWord = "";
            foreach (var letter in word)
            {
                codeWord += "_";
            }

            LevelModel model = new LevelModel()
            {
                Lives = lives,
                Score = 0,
                Word = word,
                AvailableChars = availableLetters,
                CodeWord = codeWord
            };

            _model = model;
            if (_view != null)
            {
                ShowView();
            }
        }

        
        private void CheckLevelCondition()
        {
            if (_model.Lives <= 0 ||_model.Score >= _model.Word.Length)
            {
                _view.gameObject.SetActive(false);
                _view.Destroy();
                LevelEnd?.Invoke(_model.Word, _model.Lives);
                _model = null;
            }
        }
    }
}