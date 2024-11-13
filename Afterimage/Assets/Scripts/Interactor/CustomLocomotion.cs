using System.Collections.Generic;
using UnityEngine;

namespace Interactor
{
    public class CustomLocomotion : MonoBehaviour
    {
        public List<GameObject> moveComponents;

        public void SetMovement(bool canMove)
        {
            foreach (var move in moveComponents)
            {
                move.SetActive(canMove);
            }
        }
    }
}
