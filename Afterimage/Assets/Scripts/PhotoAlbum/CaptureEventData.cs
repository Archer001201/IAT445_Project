using System;
using System.Collections.Generic;
using CameraMechanics;
using UnityEngine;

public enum PhotoType
{
    Clear, Blur, Faded
}

namespace PhotoAlbum
{
    [Serializable]
    public class CaptureEventData
    {
        public PhotoType type;
        public CaptureEvent captureEvent;
        public Material material;
        public bool isLocked;
        public CaptureEvent unlockEvent;
    }
}
