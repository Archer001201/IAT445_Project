using System;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMechanics
{
    public class CaptureZone : MonoBehaviour
    {
        public CaptureEvent captureEvent;
        public List<GameObject> objectList;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("GrabInteractableItem"))
            {
                objectList.Add(other.gameObject);
                captureEvent.UpdateExtraObjectsStatus();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("GrabInteractableItem"))
            {
                objectList.Remove(other.gameObject);
                captureEvent.UpdateExtraObjectsStatus();
            }
        }
    }
}
