using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Data;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class Delegates
    {
        public delegate void ObjectDetectionStartHandle(in ObjectDetectionContext context, in OperationResult detectionResult);
        
        public delegate void ObjectDetectionFailedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        public delegate void ObjectDetectionEndHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        public delegate void ObjectDetectedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        public delegate void ObjectGhostDetectedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);
        
        public delegate OperationResult CanBeDetectedHandle(in ObjectDetectionContext context);
    }
}