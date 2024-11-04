using System;
using PhotoAlbum;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Level
{
    public class PlayerEnterLevel : MonoBehaviour
    {
        public string lastScene;
        public LevelDataManager levelDataManager;
        public UnityEvent onEnterEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if(lastScene != string.Empty) SceneManager.UnloadSceneAsync(lastScene);
            GameObject.Find("PhotoManager").GetComponent<PhotoManager>().AssignEventAndMaterial(levelDataManager);
            onEnterEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
