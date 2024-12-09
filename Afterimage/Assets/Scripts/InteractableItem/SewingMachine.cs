using System;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableItem
{
    public class SewingMachine : MonoBehaviour
    {
        public GameObject paddle;
        public GameObject cloth;
        public bool paddlePlaced;
        public bool clothPlaced;
        public GameObject paddleOnDesk;
        public GameObject clothOnDesk;
        public UnityEvent onFinishedEvent;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.enabled = false;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == paddle)
            {
                paddlePlaced = true;
                paddle.SetActive(false);
                Destroy(paddle);
                paddleOnDesk.SetActive(true);
                AllPlaced();
            }

            if (other.gameObject == cloth)
            {
                clothPlaced = true;
                cloth.SetActive(false);
                Destroy(cloth);
                clothOnDesk.SetActive(true);
                AllPlaced();
            }
        }

        private void AllPlaced()
        {
            if (paddlePlaced && clothPlaced)
            {
                onFinishedEvent?.Invoke();
                _animator.enabled = true;
            }
        }
    }
}
