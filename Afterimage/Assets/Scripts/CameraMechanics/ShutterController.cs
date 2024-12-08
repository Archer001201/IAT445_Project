using System;
using UnityEngine;

namespace CameraMechanics
{
    public class ShutterController : MonoBehaviour
    {
        public float maxRayDistance = 5f;
        public AudioClip shutterSfx;
        public AudioClip beepSfx;
        public Camera virtualCamera;
        public GameObject screenOutliner;
        public bool isGrabbing;
        
        private AudioSource audioSource;
        private bool canCapture;
        [SerializeField] private CaptureEvent captureEvent;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            // screenOutliner.SetActive(false);
        }

        private void Update()
        {
            if (!isGrabbing) return;
            
            var rayOrigin = virtualCamera.transform.position;
            var rayDirection = virtualCamera.transform.forward;

            if (Physics.Raycast(rayOrigin, rayDirection, out var hit, maxRayDistance,
                    LayerMask.GetMask("Event Trigger"), QueryTriggerInteraction.Collide))
            {
                if (hit.transform.CompareTag("CaptureEventTrigger"))
                {
                    if (captureEvent == null)
                    {
                        captureEvent = hit.transform.GetComponent<CaptureEvent>();
                    }
                }
                else captureEvent = null;
            }
            else captureEvent = null;

            canCapture = captureEvent != null && captureEvent.allKeyObjectsPlaced && captureEvent.noExtraObjectsPlaced;
            if (canCapture)
            {
                if (!screenOutliner.activeSelf)
                {
                    screenOutliner.SetActive(true);
                    if (audioSource != null && beepSfx != null)
                    {
                        audioSource.PlayOneShot(beepSfx);
                    }
                }
            }
            else if (screenOutliner.activeSelf) screenOutliner.SetActive(false);
            if (captureEvent != null && captureEvent.allKeyObjectsPlaced && captureEvent.noExtraObjectsPlaced)
            {
                if (!canCapture)
                {
                    canCapture = true;
                    audioSource.PlayOneShot(beepSfx);
                }
            }
            else
            {
                canCapture = false;
            }
            
            Debug.DrawRay(rayOrigin, rayDirection * maxRayDistance, Color.red);
        }

        public void PressShutter()
        {
            if (audioSource != null && shutterSfx != null)
            {
                audioSource.PlayOneShot(shutterSfx);
            }

            if (captureEvent == null || !captureEvent.allKeyObjectsPlaced || !captureEvent.noExtraObjectsPlaced) return;
            
            captureEvent.onFinishedEvent.Invoke();
        }

        public void SetIsGrabbing(bool result)
        {
            isGrabbing = result;
        }
    }
}
