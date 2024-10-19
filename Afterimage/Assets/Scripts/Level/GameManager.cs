using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameManager : MonoBehaviour
    {
        public bool playInEditor;
        public int currentSceneIndex;
        public List<string> sceneList;
        
        private void Awake()
        {
            if (playInEditor) return;
            SceneManager.LoadScene(sceneList[currentSceneIndex], LoadSceneMode.Additive);
        }

        public void AddNextScene()
        {
            currentSceneIndex++;
            SceneManager.LoadSceneAsync(sceneList[currentSceneIndex], LoadSceneMode.Additive);
        }

        public void RemovePreviousScene()
        {
            SceneManager.UnloadSceneAsync(sceneList[currentSceneIndex - 1]);
        }
    }
}
