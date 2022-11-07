using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Game.View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _button;

        public void Show(string message, Action onClick)
        {
            _text.text = message;
            _button.onClick.AddListener(() =>
            {
                onClick?.Invoke();
                _button.onClick.RemoveAllListeners();
            });
        }
    }
}