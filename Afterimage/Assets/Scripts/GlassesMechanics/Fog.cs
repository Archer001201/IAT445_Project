using System;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace GlassesMechanics
{
    public class Fog : MonoBehaviour
    {
        public GameObject obj;
        public GameObject fog;

        private void Start()
        {
            EventHandler.onGlassesStateChange += ChangeVisibleState;
        }

        public void ChangeVisibleState(bool objIsVisible)
        {
            obj.SetActive(objIsVisible);
            fog.SetActive(!objIsVisible);
        }
    }
}
