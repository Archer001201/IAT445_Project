using System;
using UnityEngine;

namespace PhotoAlbum
{
    public class PhotoFilm : MonoBehaviour
    {
        public CaptureEventAndMaterial eventAndMaterial;
        public GameObject checkMark;
        public Material defaultMaterial;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void ResetPhotoFilm()
        {
            checkMark.SetActive(false);
            meshRenderer.material = !eventAndMaterial.isLocked ? eventAndMaterial.material : defaultMaterial;
            if (eventAndMaterial.captureEvent != null)
            {
                eventAndMaterial.captureEvent.onFinishedEvent.AddListener(ActivateCheckMark);
            }

            if (eventAndMaterial.isLocked && eventAndMaterial.unlockEvent != null)
            {
                eventAndMaterial.unlockEvent.onFinishedEvent.AddListener(UnlockPhoto);
            }
        }

        public void ActivateCheckMark()
        {
            checkMark.SetActive(true);
        }

        public void UnlockPhoto()
        {
            eventAndMaterial.isLocked = false;
            meshRenderer.material = !eventAndMaterial.isLocked ? eventAndMaterial.material : defaultMaterial;
        }
    }
}
