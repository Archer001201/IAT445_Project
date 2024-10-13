using System;
using UnityEngine;

namespace CameraMechanics
{
    public class PlacementZone : MonoBehaviour
    {
        public GameObject target;
        public bool isPlaced;
        public CaptureEvent captureEvent;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == target)
            {
                isPlaced = true;
                captureEvent.UpdateKeyObjectsStatus();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == target)
            {
                isPlaced = false;
                captureEvent.allKeyObjectsPlaced = false;
            }
        }
    }
}
