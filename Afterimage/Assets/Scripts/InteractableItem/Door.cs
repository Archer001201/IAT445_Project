using System;
using UnityEngine;

namespace InteractableItem
{
    public class Door : MonoBehaviour
    {
        public Transform doorTransform;
        public float targetAngle = 90f;
        public float rotateSpeed = 2f;
        private Quaternion targetRotation;
        private bool isRotating;

        private void Awake()
        {
            targetRotation = Quaternion.Euler(0, targetAngle, 0);
        }
        
        public void OnDoorReleased()
        {
            isRotating = true;
        }

        private void Update()
        {
            if (isRotating)
            {
                doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
                
                if (Quaternion.Angle(doorTransform.rotation, targetRotation) < 0.1f)
                {
                    doorTransform.rotation = targetRotation; 
                    isRotating = false;  
                }
            }
        }
    }
}
