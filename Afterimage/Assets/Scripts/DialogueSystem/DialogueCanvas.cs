using System;
using System.Collections;
using System.Collections.Generic;
using Interactor;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using EventHandler = Utilities.EventHandler;

namespace DialogueSystem
{
    public class DialogueCanvas : MonoBehaviour
    {
        public GameObject dialoguePanel;
        public TextMeshProUGUI contentText;

        private AudioSource audioSource;
        private Coroutine dialogueCoroutine;
        private CustomLocomotion locomotion;

        private void Awake()
        {
            contentText.text = string.Empty;
            audioSource = GetComponent<AudioSource>();
            locomotion = GameObject.FindWithTag("Locomotion").GetComponent<CustomLocomotion>();
        }

        private void OnEnable()
        {
            EventHandler.onDialogue += StartDialogueCoroutine;
        }

        private void OnDisable()
        {
            EventHandler.onDialogue -= StartDialogueCoroutine;
        }

        private void StartDialogueCoroutine(DialogueProvider provider)
        {
            if (dialogueCoroutine != null) return;
            dialogueCoroutine = StartCoroutine(PlayDialogue(provider));
        }

        private void StopDialogueCoroutine()
        {
            if (dialogueCoroutine == null) return;
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
        }

        private IEnumerator PlayDialogue(DialogueProvider provider)
        {
            dialoguePanel.SetActive(true);
            locomotion.SetMovement(provider.canMove);
            provider.onStartedEvent?.Invoke();
            EventHandler.CameraUpdate(false);
            yield return new WaitForSeconds(provider.waitBeforeAudioStart);
            foreach (var piece in provider.dialoguePieces)
            {
                // yield return new WaitForSeconds(0.5f);
                contentText.text = piece.content;
                audioSource.clip = piece.audioClip;
                audioSource.Play();
                yield return new WaitUntil(() => !audioSource.isPlaying);
            }
            provider.onFinishedEvent?.Invoke();
            EventHandler.CameraUpdate(true);
            dialoguePanel.SetActive(false);
            locomotion.SetMovement(true);
            StopDialogueCoroutine();
        }
    }
}
