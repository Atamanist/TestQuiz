using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Project.Level.View
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _lives;
        [SerializeField] private RectTransform _container;
        [SerializeField] private LetterButton _letterButton;

        private List<GameObject> _items;

        public void Init(string word, string letters, int lives, Action<char> charClicked)
        {
            _items = new List<GameObject>();
            _text.text = word;
            _lives.text = $"Lives: {lives}";
            foreach (var letter in letters)
            {
                var item = Instantiate(_letterButton, _container);
                item.Init(letter);
                item.Button.onClick.AddListener(() =>
                {
                    charClicked?.Invoke(letter);
                    Destroy(item.gameObject);
                });
                _items.Add(item.gameObject);
            }
        }

        public void ChangeText(string word, int lives)
        {
            _text.text = word;
            _lives.text = $"Lives: {lives}";
        }

        public void Destroy()
        {
            foreach (var item in _items)
            {
                Destroy(item.gameObject);
            }

            _items.Clear();
        }
    }
}