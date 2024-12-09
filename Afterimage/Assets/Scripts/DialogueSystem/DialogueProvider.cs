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
        public UnityEvent onStartedEvent;
        public UnityEvent onFinishedEvent;
        public float waitBeforeAudioStart;

        private void Awake()
        {
            GetComponent<MeshRenderer>().enabled = false;   
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            EventHandler.Dialogue(this);
            // EventHandler.CameraUpdate(false);
            if (triggerOnce) gameObject.SetActive(false);
        }
    }
}
