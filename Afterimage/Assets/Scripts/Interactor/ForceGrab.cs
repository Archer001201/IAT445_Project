using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Interactor
{
    public class ForceGrab : MonoBehaviour
    {
        public XRRayInteractor rayInteractor;      // 远距离抓取用的 XR Ray Interactor
        public XRDirectInteractor directInteractor; // 近距离交互用的 XR Direct Interactor
        private XRInteractionManager interactionManager;

        private void Start()
        {
            // 确保两个 Interactor 存在
            if (rayInteractor == null)
                rayInteractor = GetComponent<XRRayInteractor>();

            if (directInteractor == null)
                Debug.LogError("Please assign a Direct Interactor!");
            
            // 获取 Interaction Manager
            interactionManager = directInteractor.interactionManager;

            // 监听 Ray Interactor 的抓取事件
            rayInteractor.selectEntered.AddListener(OnRaySelectEntered);
        }

        private void OnRaySelectEntered(SelectEnterEventArgs args)
        {
            // 抓取物体时，将物体切换到 Direct Interactor
            GameObject grabbedObject = args.interactableObject.transform.gameObject;

            // 解绑 Ray Interactor，让 Direct Interactor 控制物体
            TransferControlToDirectInteractor(grabbedObject);
        }

        private void TransferControlToDirectInteractor(GameObject grabbedObject)
        {
            // 首先解除物体和 Ray Interactor 的联系
            rayInteractor.allowSelect = false; // 禁用 Ray Interactor 的抓取功能

            // 手动将物体交给 Direct Interactor
            XRGrabInteractable grabInteractable = grabbedObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && directInteractor != null)
            {
                // 使用新的 SelectEnter 方法
                interactionManager.SelectEnter(directInteractor as IXRSelectInteractor, grabInteractable as IXRSelectInteractable);
            }

            // 重新启用 Ray Interactor 抓取功能（可选）
            rayInteractor.allowSelect = true;
        }
    }
}
