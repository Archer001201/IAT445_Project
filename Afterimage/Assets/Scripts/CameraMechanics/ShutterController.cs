using System;
using UnityEngine;

namespace CameraMechanics
{
    public class ShutterController : MonoBehaviour
    {
        public float maxRayDistance = 5f;
        public AudioClip shutterSfx;
        public Camera virtualCamera;
        
        private AudioSource audioSource;
        [SerializeField] private CaptureEvent captureEvent;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            var rayOrigin = virtualCamera.transform.position;
            var rayDirection = virtualCamera.transform.forward;

            if (Physics.Raycast(rayOrigin, rayDirection, out var hit, maxRayDistance, LayerMask.GetMask("Event Trigger"), QueryTriggerInteraction.Collide))
            {
                if (hit.transform.CompareTag("CaptureEventTrigger") && captureEvent == null)
                    captureEvent = hit.transform.GetComponent<CaptureEvent>();
                else captureEvent = null;
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
    }
}
