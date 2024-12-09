using System;
using System.Collections.Generic;
using CameraMechanics;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace GlassesMechanics
{
    public class Glasses : Inventory
    {
        // public Inventory baseInventory;
        public Vector3 positionOffset2; 
        public Quaternion localRotationOffset2;
        public bool isWearing;

        protected override void Update()
        {
            if (!allowAttach) return;
            
            if (isCarried)
            {
                var horizontalRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                var targetPosition = cameraTransform.position + horizontalRotation * positionOffset;
                // transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
                transform.position = targetPosition;
                var targetRotation = horizontalRotation * localRotationOffset;
                // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
                transform.rotation = targetRotation;
            }

            if (isWearing)
            {
                var horizontalRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                var targetPosition = cameraTransform.position + horizontalRotation * positionOffset2;
                // transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
                transform.position = targetPosition;
                var targetRotation = horizontalRotation * localRotationOffset2;
                // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
                transform.rotation = targetRotation;
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("GlassesTrigger")) return;
            if (!allowAttach) return;
            if (isGrabbed) return;
            // baseInventory.enabled = false;
            // baseInventory.allowAttach = false;  
            isWearing = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            
            EventHandler.ChangeGlassesState(true);
        }
        
        // private void OnTriggerExit(Collider other)
        // {
        //     if (!other.CompareTag("GlassesTrigger")) return;
        //     // baseInventory.enabled = true;
        //     // baseInventory.allowAttach = true;  
        // }

        public override void SetGrabStatus(bool result)
        {
            base.SetGrabStatus(result);

            if (result)
            {
                isWearing = false;
                EventHandler.ChangeGlassesState(false);
            }
        }
    }
}
