using System;
using UnityEngine;

namespace Utilities
{
    public class BgmPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            EventHandler.onPlayerBgm += PlayBgm;
        }

        private void OnDisable()
        {
            EventHandler.onPlayerBgm -= PlayBgm;
        }

        private void PlayBgm(AudioClip clip)
        {
            if (_audioSource.clip) _audioSource.Pause();
            if (clip == null) _audioSource.Pause();
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
