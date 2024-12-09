using System;
using UnityEngine;

namespace Utilities
{
    public class AnimationControl : MonoBehaviour
    {
        public Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void SetSwitchAnim(bool turnOn)
        {
            anim.SetBool("Switch", turnOn);
        }

        public void SetIdleAnim2(bool turnOn)
        {
            anim.SetBool("Idle2", turnOn);
        }
    }
}
