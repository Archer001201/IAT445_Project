using System;
using CameraMechanics;
using UnityEngine;

namespace PhotoAlbum
{
    [Serializable]
    public class CaptureEventAndMaterial
    {
        public CaptureEvent captureEvent;
        public Material material;
        public bool isLocked;
        public CaptureEvent unlockEvent;
    }
}
