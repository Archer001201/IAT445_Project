using System;
using UnityEngine;

namespace Interactor
{
    public class InteractorLine : MonoBehaviour
    {
        public Material defaultColor;
        public Material hoveredColor;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            meshRenderer.material = defaultColor;
        }

        public void ChangeColor(bool isHovered)
        {
            meshRenderer.material = isHovered ? hoveredColor : defaultColor;
        }

        public void HideLine(bool isHided)
        {
            meshRenderer.enabled = isHided;
        }
    }
}
