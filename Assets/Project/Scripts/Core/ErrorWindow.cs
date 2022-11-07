using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class ErrorWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Show(string message)
    {
        _text.text = message;
    }
}
