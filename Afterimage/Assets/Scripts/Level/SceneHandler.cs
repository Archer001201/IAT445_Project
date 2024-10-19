using System;
using UnityEngine;

namespace Level
{
    public class SceneHandler : MonoBehaviour
    {
        public GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        public void LoadNextScene()
        {
            gameManager.AddNextScene();
        }
    }
}
