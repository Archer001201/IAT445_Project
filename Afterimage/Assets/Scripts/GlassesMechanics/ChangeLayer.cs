using UnityEngine;

namespace GlassesMechanics
{
    public class ChangeLayer : MonoBehaviour
    {
        public LayerMask targetLayer;
        
        public void LayerChange()
        {
            gameObject.layer = targetLayer;
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.layer = targetLayer;
            }
        }
    }
}
