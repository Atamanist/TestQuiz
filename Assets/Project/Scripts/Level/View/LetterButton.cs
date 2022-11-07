using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Level.View
{
    public class LetterButton : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }
        [SerializeField] private TextMeshProUGUI _Text;
        private char _letter;

        public void Init(char letter)
        {
            _letter = letter;
            _Text.text = _letter.ToString();
        }
    }
}