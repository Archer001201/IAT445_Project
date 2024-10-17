using System;
using System.Collections.Generic;
using CameraMechanics;
using UnityEngine;

namespace PhotoAlbum
{
    [Serializable]
    public class CaptureEventData
    {
        public CaptureEvent captureEvent;
        public Material material;
        public bool isLocked;
        public CaptureEvent unlockEvent;
    }
}
