using System;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace GlassesMechanics
{
    public class CameraWithGlasses : MonoBehaviour
    {
        public GameObject gameCamera;
        public GameObject photoAlbum;
        public GameObject cameraFilter;

        private void Start()
        {
            EventHandler.onGlassesStateChange += OnGlassesStateChange;
        }

        public void OnGlassesStateChange(bool isWearing)
        {
            gameCamera.SetActive(!isWearing);
            photoAlbum.SetActive(!isWearing);
            cameraFilter.SetActive(isWearing);
        }
    }
}
