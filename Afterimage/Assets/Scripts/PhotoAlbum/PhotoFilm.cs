using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhotoAlbum
{
    public class PhotoFilm : MonoBehaviour
    {
        [FormerlySerializedAs("eventAndMaterial")] public CaptureEventData eventData;
        public GameObject checkMark;
        public GameObject crossMark;
        public Material defaultMaterial;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void ResetPhotoFilm()
        {
            checkMark.SetActive(false);
            meshRenderer.material = !eventData.isLocked ? eventData.material : defaultMaterial;
            crossMark.SetActive(eventData.isLocked);
            if (eventData.captureEvent != null)
            {
                eventData.captureEvent.onFinishedEvent.AddListener(ActivateCheckMark);
            }

            if (eventData.isLocked && eventData.unlockEvent != null)
            {
                eventData.unlockEvent.onFinishedEvent.AddListener(UnlockPhoto);
            }
        }

        public void ActivateCheckMark()
        {
            checkMark.SetActive(true);
        }

        public void UnlockPhoto()
        {
            eventData.isLocked = false;
            crossMark.SetActive(false);
            meshRenderer.material = !eventData.isLocked ? eventData.material : defaultMaterial;
        }
    }
}
