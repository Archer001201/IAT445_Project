using System;
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
    }
}
