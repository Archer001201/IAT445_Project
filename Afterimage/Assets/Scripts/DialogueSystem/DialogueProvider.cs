using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EventHandler = Utilities.EventHandler;

namespace DialogueSystem
{
    public class DialogueProvider : MonoBehaviour
    {
        public bool triggerOnce = true;
        public bool canMove;
        public List<DialoguePiece> dialoguePieces;
        public UnityEvent onFinishedEvent;

        private void Awake()
        {
            GetComponent<MeshRenderer>().enabled = false;   
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            EventHandler.Dialogue(this);
            if (triggerOnce) gameObject.SetActive(false);
        }
    }
}
