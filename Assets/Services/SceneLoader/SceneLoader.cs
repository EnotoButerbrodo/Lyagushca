using System;
using System.Collections;
using Lyaguska.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lyaguska.Services.SceneLoader
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _runner;

        public SceneLoader(ICoroutineRunner runner)
        {
            _runner = runner;
        }

        public void Load(string name, Action onLoaded) =>
            _runner.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (waitNextScene.isDone == false)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}