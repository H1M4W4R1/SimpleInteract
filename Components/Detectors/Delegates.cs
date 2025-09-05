using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Data;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class Delegates
    {
        internal delegate void ObjectDetectionStartHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        internal delegate void ObjectDetectionFailedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        internal delegate void ObjectDetectionEndHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        internal delegate void ObjectDetectedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        internal delegate void ObjectGhostDetectedHandle(in ObjectDetectionContext context, in OperationResult detectionResult);

        internal delegate OperationResult CanBeDetectedHandle(in ObjectDetectionContext context);
    }
}