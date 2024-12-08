using System;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class DialoguePiece
    {
        [TextArea] public string content;
        public AudioClip audioClip;
    }
}
