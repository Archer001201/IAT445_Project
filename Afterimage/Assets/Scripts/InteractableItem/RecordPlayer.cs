using System;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableItem
{
    public class RecordPlayer : MonoBehaviour
    {
        public UnityEvent onFinishedEvent;
        public GameObject targetObject;
        public Transform attachTransform;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != targetObject) return;
            var newPosition = attachTransform.position;
            other.transform.position = newPosition;
            onFinishedEvent.Invoke();
        }
    }
}
