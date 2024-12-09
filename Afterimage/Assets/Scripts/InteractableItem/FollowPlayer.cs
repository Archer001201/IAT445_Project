using System;
using UnityEngine;

namespace InteractableItem
{
    public class FollowPlayer : MonoBehaviour
    {
        public Vector3 offset;
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindWithTag("MainCamera").transform;
        }

        private void Update()
        {
            if (_player)
            {
                transform.position = _player.position + offset;
            }
        }
    }
}
