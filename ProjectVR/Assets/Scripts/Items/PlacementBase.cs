using System;
using UnityEngine;

namespace Items
{
    public class PlacementBase : MonoBehaviour
    {
        public GameObject target;
        public bool isPlaced;
        public SnapshotEvent snapshotEvent;
        
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == target)
            {
                isPlaced = true;
                snapshotEvent.CheckPlacementStatus();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == target)
            {
                isPlaced = false;
                snapshotEvent.isAllPlaced = false;
            }
        }
    }
}
