using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace CameraMechanics
{
    public class CaptureEvent : MonoBehaviour
    {
        public UnityEvent onFinishedEvent;
        public bool allKeyObjectsPlaced;
        public bool noExtraObjectsPlaced = true;
        
        [HideInInspector] public List<PlacementZone> placementList;
        [HideInInspector] public CaptureZone captureZone;
        
        private MeshRenderer meshRenderer;
        private readonly List<GameObject> keyObjectList = new();

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;

            onFinishedEvent.AddListener(DisableCaptureEvent);
        }

        private void Start()
        {
            if (placementList.Count > 0)
            {
                foreach (var zone in placementList)
                {
                    foreach (var tar in zone.targetObjectList)
                    {
                        keyObjectList.Add(tar);
                    }
                }
            }
            else allKeyObjectsPlaced = true;
        }

        public void UpdateKeyObjectsStatus()
        {
            foreach (var zone in placementList)
            {
                if (!zone.isPlaced)
                {
                    allKeyObjectsPlaced = false;
                    return;
                }
            }

            allKeyObjectsPlaced = true;
        }

        public void UpdateExtraObjectsStatus()
        {
            if (captureZone == null) return;
            foreach (var obj in captureZone.objectList)
            {
                if (!keyObjectList.Contains(obj))
                {
                    noExtraObjectsPlaced = false;
                    return;
                }
            }

            noExtraObjectsPlaced = true;
        }

        private void DisableCaptureEvent()
        {
            foreach (var zone in placementList)
            {
                zone.gameObject.SetActive(false);
            }
            
            captureZone.gameObject.SetActive(false);
            
            gameObject.SetActive(false);
        }
    }
}
