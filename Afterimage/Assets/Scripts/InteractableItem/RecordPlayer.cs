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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject != targetObject) return;
            other.transform.position = attachTransform.position;
            onFinishedEvent.Invoke();
        }
    }
}
