using System;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMechanics
{
    public class PlacementZone : MonoBehaviour
    {
        public List<GameObject> targetObjectList;
        public CaptureEvent captureEvent;
        public bool isPlaced;
        

        private int targetCount;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
            
            captureEvent.placementList.Add(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (targetObjectList.Contains(other.gameObject))
            {
                targetCount++;
                if (targetCount == targetObjectList.Count)
                {
                    isPlaced = true;
                    captureEvent.UpdateKeyObjectsStatus(); 
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (targetObjectList.Contains(other.gameObject))
            {
                targetCount--;
                isPlaced = false;
                captureEvent.allKeyObjectsPlaced = false;
            }
        }
    }
}
