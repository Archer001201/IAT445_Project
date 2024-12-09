using System;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace GlassesMechanics
{
    public class GrassField : MonoBehaviour
    {
        public GameObject grass;

        private void Start()
        {
            EventHandler.onGlassesStateChange += b => SetGrassState(!b);
        }

        private void SetGrassState(bool isActive)
        {
            grass.SetActive(isActive);
        }
    }
}
