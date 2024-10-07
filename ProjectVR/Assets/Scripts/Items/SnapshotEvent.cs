using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    public class SnapshotEvent : MonoBehaviour
    {
        public UnityEvent onFinishedEvent;
        public List<PlacementBase> baseList;
        public bool isAllPlaced;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;
        }

        private void Start()
        {
            if (baseList.Count > 0)
            {
                foreach (var baseObj in baseList)
                {
                    baseObj.snapshotEvent = this;
                } 
            }
            else
            {
                isAllPlaced = true;
            }
        }

        public void CheckPlacementStatus()
        {
            foreach (var baseObj in baseList)
            {
                if (!baseObj.isPlaced)
                {
                    isAllPlaced = false;
                    return;
                }
            }
            
            isAllPlaced = true;
        }
    }
}
