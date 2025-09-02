using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleDetection.Data;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class Delegates
    {
        public delegate void ObjectDetectionStartHandle(in ObjectDetectionContext context);
        
        public delegate void ObjectDetectionFailedHandle(in ObjectDetectionContext context);

        public delegate void ObjectDetectionEndHandle(in ObjectDetectionContext context);

        public delegate void ObjectDetectedHandle(in ObjectDetectionContext context);

        public delegate void ObjectGhostDetectedHandle(in ObjectDetectionContext context);
        
        public delegate bool CanBeDetectedHandle(in ObjectDetectionContext context);
    }
}