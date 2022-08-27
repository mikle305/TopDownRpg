using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private Button _button;

    [Header("Game scene params")] 
    [SerializeField]
    private string _gameSceneName;
    
    private void Start()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        SceneController.LoadScene(_gameSceneName);
    }
}
