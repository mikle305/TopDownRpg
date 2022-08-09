using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SceneTransitionView : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TMP_Text _loadingPercent;
    [SerializeField] private Image _loadingBar;

    [Header("Scene closing animation params")]
    [SerializeField] private string _closingTriggerName;

    [Header("Scene opening animation params")]
    [SerializeField] private string _openingTriggerName;

    private Animator _animator;
    private AsyncOperation _loadingSceneOperation;

    public event Action CloseSceneAnimationEnded;

    public void Init(AsyncOperation loadingSceneOperation)
    {
        _loadingSceneOperation = loadingSceneOperation;
    }

    public void OnSceneLoadingStarted()
    {
        _animator.SetTrigger(_closingTriggerName);
    }

    public void OnSceneLoadingEnded()
    {
        _animator.SetTrigger(_openingTriggerName);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (_loadingSceneOperation == null) return;
        _loadingPercent.text = $"{Mathf.RoundToInt(_loadingSceneOperation.progress * 100)}%";
        _loadingBar.fillAmount = _loadingSceneOperation.progress;

    }

    public void OnCloseSceneAnimationOver()
    {
        CloseSceneAnimationEnded?.Invoke();
    }
}
