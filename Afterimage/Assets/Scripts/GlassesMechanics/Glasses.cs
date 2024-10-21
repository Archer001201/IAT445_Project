using System;
using System.Collections.Generic;
using CameraMechanics;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace GlassesMechanics
{
    public class Glasses : Inventory
    {
        protected override void OnCollisionEnter(Collision other){}

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("GlassesTrigger")) return;
            if (!allowAttach) return;
            if (isGrabbed) return;
            isCarried = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            
            EventHandler.ChangeGlassesState(true);
        }

        public override void SetGrabStatus(bool result)
        {
            base.SetGrabStatus(result);
            
            if (result) EventHandler.ChangeGlassesState(false);
        }
    }
}
