using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace Interactor
{
    public class HoverUiWithTag : MonoBehaviour
    {
        public float rayDistance = 1f;
        public GameObject hoverUI;
        public string targetTag = "TargetTag";
        public LayerMask raycastLayers;

        private static GameObject _currentHitObject = null;  // 静态变量，确保多个控制器共享
        private static HoverUiWithTag _activeController = null; // 确保只有一个控制器在控制 UI

        private void Start()
        {
            if (hoverUI != null)
            {
                hoverUI.SetActive(false);
            }
        }

        private void Update()
        {
            PerformRaycast();
        }

        private void PerformRaycast()
        {
            var ray = new Ray(transform.position, transform.forward);

            // 检查是否有物体被命中
            if (Physics.Raycast(ray, out var hit, rayDistance, raycastLayers, QueryTriggerInteraction.Collide))
            {
                // 确保命中目标标签物体
                if (hit.collider.CompareTag(targetTag))
                {
                    var hitObject = hit.collider.gameObject;

                    // 如果当前没有其他控制器在处理，或者当前控制器为激活的控制器
                    if (_currentHitObject != hitObject || _activeController == this)
                    {
                        _currentHitObject = hitObject;
                        _activeController = this;

                        // 如果 UI 是非激活状态，激活它
                        if (hoverUI != null && !hoverUI.activeSelf)
                        {
                            Debug.Log(hitObject.name);
                            hoverUI.GetComponentInChildren<Image>().material =
                                hitObject.GetComponent<MeshRenderer>().material;

                            hoverUI.SetActive(true);
                        }
                    }
                }
                else
                {
                    HideUI();
                }
            }
            else
            {
                HideUI();
            }
        }

        private void HideUI()
        {
            // 只有当前控制器可以隐藏 UI
            if (hoverUI != null && hoverUI.activeSelf && _activeController == this)
            {
                hoverUI.SetActive(false);
                hoverUI.GetComponentInChildren<Image>().material = null;
                _activeController = null;  // 释放控制器
                _currentHitObject = null;  // 清除命中物体
            }
        }
    }
}
