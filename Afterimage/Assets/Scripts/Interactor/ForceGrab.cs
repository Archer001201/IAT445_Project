using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Interactor
{
    public class ForceGrab : MonoBehaviour
    {
        public XRRayInteractor rayInteractor;    
        public XRDirectInteractor directInteractor;
        
        private XRInteractionManager interactionManager;

        private void Start()
        {
            if (rayInteractor == null)
                rayInteractor = GetComponent<XRRayInteractor>();

            if (directInteractor == null)
                Debug.LogError("Please assign a Direct Interactor!");
            
            interactionManager = directInteractor.interactionManager;
            
            rayInteractor.selectEntered.AddListener(OnRaySelectEntered);
            directInteractor.selectExited.AddListener(OnDirectSelectExited);
            rayInteractor.selectExited.AddListener(OnRaySelectExited);
        }

        private void OnRaySelectEntered(SelectEnterEventArgs args)
        {
            var grabbedObject = args.interactableObject.transform.gameObject;

            TransferControlToDirectInteractor(grabbedObject);
        }

        private void TransferControlToDirectInteractor(GameObject grabbedObject)
        {
            rayInteractor.allowSelect = false;

            var grabInteractable = grabbedObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && directInteractor != null)
            {
                interactionManager.SelectEnter(directInteractor as IXRSelectInteractor, grabInteractable);
            }
        }
        
        private void OnDirectSelectExited(SelectExitEventArgs args)
        {
            rayInteractor.allowSelect = true;
        }
        
        private void OnRaySelectExited(SelectExitEventArgs args)
        {
            rayInteractor.allowSelect = true;
        }
    }
}
