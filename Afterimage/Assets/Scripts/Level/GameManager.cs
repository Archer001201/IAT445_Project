using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameManager : MonoBehaviour
    {
        public bool playInEditor;
        
        public string startScene;
        
        private void Awake()
        {
            if (playInEditor) return;
            AddScene(startScene);
        }

        public void AddScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
