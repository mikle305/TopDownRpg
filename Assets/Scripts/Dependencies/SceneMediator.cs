using System;
using UnityEngine;

namespace Dependencies
{
    public class SceneMediator: MonoBehaviour
    {
        [SerializeField] private SceneTransitionView _sceneTransitionView;

        private void Start()
        {
            SceneController.SceneLoadingStarted += _sceneTransitionView.OnSceneLoadingStarted;
            SceneController.SceneLoadingStarted += OnSceneLoadingStarted;
            SceneController.SceneLoadingEnded += _sceneTransitionView.OnSceneLoadingEnded;
            _sceneTransitionView.CloseSceneAnimationEnded += SceneController.OnCloseSceneAnimationEnded;
        }

        private void OnDestroy()
        {
            SceneController.SceneLoadingStarted -= _sceneTransitionView.OnSceneLoadingStarted;
            SceneController.SceneLoadingStarted -= OnSceneLoadingStarted;
            SceneController.SceneLoadingEnded -= _sceneTransitionView.OnSceneLoadingEnded;
            _sceneTransitionView.CloseSceneAnimationEnded -= SceneController.OnCloseSceneAnimationEnded;
        }

        private void OnSceneLoadingStarted()
        {
            _sceneTransitionView.Init(SceneController.LoadingSceneOperation);
        }
    }
}