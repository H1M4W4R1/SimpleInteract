using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Components.Detectors.Base;
using Systems.SimpleDetection.Data;
using Systems.SimpleDetection.Operations;
using Systems.SimpleInteract.Components.Detectors.Abstract;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class InteractableDetector3D : Sphere3DDetector, IInteractableDetector
    {

#region Internal events

        private event Delegates.ObjectDetectedHandle ObjectDetected;
        private event Delegates.ObjectDetectionFailedHandle ObjectDetectionFailed;
        private event Delegates.ObjectDetectionEndHandle ObjectDetectionEnd;
        private event Delegates.ObjectDetectionStartHandle ObjectDetectionStart;
        private event Delegates.ObjectGhostDetectedHandle ObjectGhostDetected;
        private event Delegates.CanBeDetectedHandle ObjectCanBeDetected;

        event Delegates.ObjectDetectedHandle IInteractableDetector.ObjectDetected
        {
            add => ObjectDetected += value;
            remove => ObjectDetected -= value;
        }

        event Delegates.ObjectDetectionFailedHandle IInteractableDetector.ObjectDetectionFailed
        {
            add => this.ObjectDetectionFailed += value;
            remove => this.ObjectDetectionFailed -= value;
        }

        event Delegates.ObjectDetectionEndHandle IInteractableDetector.ObjectDetectionEnd
        {
            add => this.ObjectDetectionEnd += value;
            remove => this.ObjectDetectionEnd -= value;
        }

        event Delegates.ObjectDetectionStartHandle IInteractableDetector.ObjectDetectionStart
        {
            add => this.ObjectDetectionStart += value;
            remove => this.ObjectDetectionStart -= value;
        }

        event Delegates.ObjectGhostDetectedHandle IInteractableDetector.ObjectGhostDetected
        {
            add => this.ObjectGhostDetected += value;
            remove => this.ObjectGhostDetected -= value;
        }

        event Delegates.CanBeDetectedHandle IInteractableDetector.ObjectCanBeDetected
        {
            add => this.ObjectCanBeDetected += value;
            remove => this.ObjectCanBeDetected -= value;
        }

#endregion

        protected override OperationResult CanDetect(in ObjectDetectionContext context)
        {
            OperationResult baseDetection = base.CanDetect(context);
            if (!baseDetection) return baseDetection;

            if(ObjectCanBeDetected is null) return DetectionOperations.Permitted();
            return ObjectCanBeDetected.Invoke(context);
        }

        protected override void OnObjectDetectionStart(in ObjectDetectionContext context, in OperationResult detectionResult)
        {
            base.OnObjectDetectionStart(context, detectionResult);
            ObjectDetectionStart?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetectionEnd(in ObjectDetectionContext context, in OperationResult detectionResult)
        {
            base.OnObjectDetectionEnd(context, detectionResult);
            ObjectDetectionEnd?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetectionFailed(in ObjectDetectionContext context, in OperationResult detectionResult)
        {
            base.OnObjectDetectionFailed(context, detectionResult);
            ObjectDetectionFailed?.Invoke(context, detectionResult);
        }

        protected override void OnObjectDetected(in ObjectDetectionContext context, in OperationResult detectionResult)
        {
            base.OnObjectDetected(context, detectionResult);
            ObjectDetected?.Invoke(context, detectionResult);
        }

        protected override void OnObjectGhostDetected(in ObjectDetectionContext context, in OperationResult detectionResult)
        {
            ObjectGhostDetected?.Invoke(context, detectionResult);
        }
    }
}