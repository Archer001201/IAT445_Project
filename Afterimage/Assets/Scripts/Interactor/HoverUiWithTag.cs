using System;
using PhotoAlbum;
using TMPro;
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

        private static GameObject _currentHitObject;
        private static HoverUiWithTag _activeController;

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

            if (Physics.Raycast(ray, out var hit, rayDistance, raycastLayers, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    var hitObject = hit.collider.gameObject;

                    if (_currentHitObject != hitObject || _activeController == this)
                    {
                        _currentHitObject = hitObject;
                        _activeController = this;

                        if (hoverUI != null && !hoverUI.activeSelf)
                        {
                            hoverUI.GetComponentInChildren<Image>().material =
                                hitObject.GetComponent<MeshRenderer>().material;

                            var photoData = hitObject.GetComponent<PhotoFilm>().eventData;
                            var str = photoData.type.ToString() + " Photo";
                            if (photoData.isLocked) str += " (Locked)";
                            
                            hoverUI.GetComponentInChildren<TextMeshProUGUI>().text = str;

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
            if (hoverUI != null && hoverUI.activeSelf && _activeController == this)
            {
                hoverUI.SetActive(false);
                hoverUI.GetComponentInChildren<Image>().material = null;
                _activeController = null;
                _currentHitObject = null;
            }
        }
    }
}
