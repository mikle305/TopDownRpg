using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    private static AsyncOperation _loadingSceneOperation;

    public static event Action SceneLoadingStarted;
    
    public static event Action SceneLoadingEnded;

    public static AsyncOperation LoadingSceneOperation => _loadingSceneOperation;

    public static void LoadScene(string sceneName)
    {
        
        _loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        SceneLoadingStarted?.Invoke();
        _loadingSceneOperation.allowSceneActivation = false;
    }

    public static void OnCloseSceneAnimationEnded()
    {
        SceneLoadingEnded?.Invoke();
        _loadingSceneOperation.allowSceneActivation = true;
    }
}