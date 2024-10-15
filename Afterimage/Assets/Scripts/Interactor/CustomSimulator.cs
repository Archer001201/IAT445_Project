using System;
using CameraMechanics;
using UnityEngine;

namespace Interactor
{
    public class CustomSimulator : MonoBehaviour
    {
        public GameObject gameCamera;
        public GameObject album;

        private void Awake()
        {
            gameCamera.GetComponent<Inventory>().allowAttach = false;
            album.GetComponent<Inventory>().allowAttach = false;
        }
    }
}
