using UnityEngine;

namespace Utilities
{
    public class BgmProvider : MonoBehaviour
    {
        public AudioClip music;

        public void PlayMusic()
        {
            EventHandler.PlayBgm(music);
        }
    }
}
