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
        public UnityEvent onEnterEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            SceneManager.UnloadSceneAsync(lastScene);
            GameObject.Find("PhotoManager").GetComponent<PhotoManager>().AssignEventAndMaterial();
            onEnterEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
