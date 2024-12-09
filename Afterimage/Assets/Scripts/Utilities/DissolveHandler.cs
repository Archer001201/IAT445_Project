using System;
using System.Collections;
using INab.Dissolve;
using UnityEngine;
using UnityEngine.VFX;

namespace Utilities
{
    public class DissolveHandler : MonoBehaviour
    {
        public GameObject target;
        public bool isHided;
        public bool findMaterial;
        private Coroutine _vfxCoroutine;
        private Dissolver _dissolver;
        // private Collider _collider;

        private void Awake()
        {
            _dissolver = GetComponent<Dissolver>();
            if (findMaterial)
            {
                _dissolver.FindMaterialsInChildren();
                _dissolver.StopAllCoroutines();
            }
            // _collider = target.GetComponent<Collider>();
        }

        private void Start()
        {
            // if (!isHided) return;
            target.SetActive(!isHided);
        }

        // private void OnEnable()
        // {
        //     _dissolver.Materialize();
        // }
        //
        // private void OnDisable()
        // {
        //     _dissolver.Dissolve();
        // }

        public void PlayVfx(bool isActive)
        {
            StartCoroutine(HandleVfx(isActive));
        }
        
        // private void PlayDissolveVfx(bool isActive)
        // {
        //     if (_vfxCoroutine != null) return;
        //     _vfxCoroutine = StartCoroutine(HandleVfx(isActive));
        // }
        //
        // private void StopDissolveVfx()
        // {
        //     if (_vfxCoroutine == null) return;
        //     StopCoroutine(_vfxCoroutine);
        //     _vfxCoroutine = null;
        // }
        
        private IEnumerator HandleVfx(bool isActive)
        {
            target.SetActive(true);
            
            if (isActive)
            {
                _dissolver.Materialize();
            }
            else
            {
                _dissolver.Dissolve();
            }
        
            yield return new WaitForSeconds(_dissolver.duration);
        
            // _collider.enabled = isActive;
            if (!isActive) target.SetActive(false);
        }
    }
}
