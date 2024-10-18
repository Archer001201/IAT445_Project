using System;
using CameraMechanics;
using UnityEngine;

namespace Interactor
{
    public class CustomSimulator : MonoBehaviour
    {
        public bool allowAttach;
        public GameObject gameCamera;
        public GameObject album;

        private void Awake()
        {
            if (allowAttach) return;
            gameCamera.GetComponent<Inventory>().allowAttach = false;
            album.GetComponent<Inventory>().allowAttach = false;
        }
    }
}
