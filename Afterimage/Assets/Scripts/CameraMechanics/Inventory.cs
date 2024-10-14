using UnityEngine;

namespace CameraMechanics
{
    public class Inventory : MonoBehaviour
    {
        public Transform cameraTransform;
        public Vector3 positionOffset; 
        public Quaternion localRotationOffset;
        // public float smoothSpeed = 5f;
        public bool allowAttach = true;
        public Collider playerCollider;
        public Collider itemCollider;
        
        private bool isGrabbed;
        private bool isCarried;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Physics.IgnoreCollision(itemCollider,playerCollider,true);
        }

        private void Update()
        {
            if (!allowAttach) return;
            
            if (!isCarried) return;
            
            var horizontalRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
            var targetPosition = cameraTransform.position + horizontalRotation * positionOffset;
            // transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.position = targetPosition;
            var targetRotation = horizontalRotation * localRotationOffset;
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!allowAttach) return;
            
            if (isGrabbed) return;
            isCarried = true;
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        public void SetGrabStatus(bool result)
        {
            if (!allowAttach) return;
            
            isGrabbed = result;

            if (result)
            {
                isCarried = false;
            }
            else
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
    }
}
