using System;
using UnityEngine;

namespace PhotoAlbum
{
    public class PhotoFilm : MonoBehaviour
    {
        public CaptureEventAndMaterial eventAndMaterial;
        public GameObject checkMark;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void ResetPhotoFilm()
        {
            checkMark.SetActive(false);
            meshRenderer.material = eventAndMaterial.material;
            if (eventAndMaterial.captureEvent != null)
            {
                eventAndMaterial.captureEvent.onFinishedEvent.AddListener(ActivateCheckMark);
            }
        }

        public void ActivateCheckMark()
        {
            checkMark.SetActive(true);
        }
    }
}
