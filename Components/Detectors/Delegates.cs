using Systems.SimpleDetection.Components.Objects.Abstract;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class Delegates
    {
        public delegate void ObjectDetectionStartHandle(DetectableObjectBase obj);
        
        public delegate void ObjectDetectionFailedHandle(DetectableObjectBase obj);

        public delegate void ObjectDetectionEndHandle(DetectableObjectBase obj);

        public delegate void ObjectDetectedHandle(DetectableObjectBase obj);

        public delegate void ObjectGhostDetectedHandle(DetectableObjectBase obj);
        
        public delegate bool CanBeDetectedHandle(DetectableObjectBase obj);
    }
}