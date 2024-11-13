using System;
using System.Collections.Generic;
using DialogueSystem;
using UnityEngine;

namespace Utilities
{
    public static class EventHandler
    {
        public static Action<bool> onGlassesStateChange;

        public static void ChangeGlassesState(bool objIsVisible)
        {
            onGlassesStateChange?.Invoke(objIsVisible);
        }

        public static Action<List<DialoguePiece>> onDialogue;

        public static void Dialogue(List<DialoguePiece> pieces)
        {
            onDialogue?.Invoke(pieces);
        }
    }
}
