using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class Snapshot : MonoBehaviour
    {
        public Camera gameCamera;
        public float maxRayDistance = 10f;
        private SnapshotEvent _snapshotEvent;

        private void Update()
        {
            var rayOrigin = gameCamera.transform.position;
            var rayDirection = gameCamera.transform.forward;

            if (Physics.Raycast(rayOrigin, rayDirection, out var hit, maxRayDistance, LayerMask.GetMask("Event Detection"), QueryTriggerInteraction.Collide))
            {
                if (hit.transform.CompareTag("SnapshotEvent") && _snapshotEvent == null) _snapshotEvent = hit.transform.GetComponent<SnapshotEvent>();
                else _snapshotEvent = null;
            }
            Debug.DrawRay(rayOrigin, rayDirection * maxRayDistance, Color.red);
        }

        public void Shot()
        {
            if (_snapshotEvent == null || !_snapshotEvent.isAllPlaced) return;
            
            _snapshotEvent.onFinishedEvent.Invoke();
        }

    }
}
