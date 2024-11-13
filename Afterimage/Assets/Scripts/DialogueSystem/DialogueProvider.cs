using System;
using System.Collections.Generic;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace DialogueSystem
{
    public class DialogueProvider : MonoBehaviour
    {
        public bool triggerOnce = true;
        public List<DialoguePiece> dialoguePieces;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            EventHandler.Dialogue(dialoguePieces);
            if (triggerOnce) gameObject.SetActive(false);
        }
    }
}
