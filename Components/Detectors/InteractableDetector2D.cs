using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Components.Detectors.Base;
using Systems.SimpleDetection.Data;
using Systems.SimpleDetection.Operations;
using Systems.SimpleInteract.Components.Detectors.Abstract;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class InteractableDetector2D : Circle2DDetector, IInteractableDetector
    {
        public event Delegates.ObjectDetectedHandle ObjectDetected;
        public event Delegates.ObjectDetectionFailedHandle ObjectDetectionFailed;
        public event Delegates.ObjectDetectionEndHandle ObjectDetectionEnd;
        public event Delegates.ObjectDetectionStartHandle ObjectDetectionStart;
        public event Delegates.ObjectGhostDetectedHandle ObjectGhostDetected;
        public event Delegates.CanBeDetectedHandle ObjectCanBeDetected;

        protected override OperationResult CanDetect(in ObjectDetectionContext context)
        {
            OperationResult baseDetection = base.CanDetect(context);
            if (!baseDetection) return baseDetection;

            if (ObjectCanBeDetected is null) return DetectionOperations.Permitted();
            return ObjectCanBeDetected.Invoke(context);
        }

        protected override void OnObjectDetectionStart(
            in ObjectDetectionContext context,
            in OperationResult detectionResult)
        {
            base.OnObjectDetectionStart(context, detectionResult);
            ObjectDetectionStart?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetectionEnd(
            in ObjectDetectionContext context,
            in OperationResult detectionResult)
        {
            base.OnObjectDetectionEnd(context, detectionResult);
            ObjectDetectionEnd?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetectionFailed(
            in ObjectDetectionContext context,
            in OperationResult detectionResult)
        {
            base.OnObjectDetectionFailed(context, detectionResult);
            ObjectDetectionFailed?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetected(
            in ObjectDetectionContext context,
            in OperationResult detectionResult)
        {
            base.OnObjectDetected(context, detectionResult);
            ObjectDetected?.Invoke(context, detectionResult);
        }

        protected override void OnObjectGhostDetected(
            in ObjectDetectionContext context,
            in OperationResult detectionResult)
        {
            ObjectGhostDetected?.Invoke(context, detectionResult);
        }
    }
}