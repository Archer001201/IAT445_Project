using System;
using System.Collections.Generic;
using PhotoAlbum;
using UnityEngine;
using UnityEngine.Events;

namespace CameraMechanics
{
    public class CaptureEvent : MonoBehaviour
    {
        public UnityEvent onFinishedEvent;
        public List<PlacementZone> zoneList;
        public CaptureZone captureZone;
        public bool allKeyObjectsPlaced;
        public bool noExtraObjectsPlaced = true;
        
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
            if (zoneList.Count > 0)
            {
                foreach (var zone in zoneList)
                {
                    zone.captureEvent = this;
                    keyObjectList.Add(zone.target);
                }
            }
            else allKeyObjectsPlaced = true;

            captureZone.captureEvent = this;
        }

        public void UpdateKeyObjectsStatus()
        {
            foreach (var zone in zoneList)
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
            foreach (var zone in zoneList)
            {
                zone.gameObject.SetActive(false);
            }
            
            captureZone.gameObject.SetActive(false);
            
            gameObject.SetActive(false);
        }
    }
}
