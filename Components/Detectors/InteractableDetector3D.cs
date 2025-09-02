using Systems.SimpleDetection.Components.Detectors.Base;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleDetection.Data;
using Systems.SimpleInteract.Components.Detectors.Abstract;

namespace Systems.SimpleInteract.Components.Detectors
{
    public sealed class InteractableDetector3D : Sphere3DDetector, IInteractableDetector
    {
        public event Delegates.ObjectDetectedHandle ObjectDetected;
        public event Delegates.ObjectDetectionFailedHandle ObjectDetectionFailed;
        public event Delegates.ObjectDetectionEndHandle ObjectDetectionEnd;
        public event Delegates.ObjectDetectionStartHandle ObjectDetectionStart;
        public event Delegates.ObjectGhostDetectedHandle ObjectGhostDetected;
        public event Delegates.CanBeDetectedHandle ObjectCanBeDetected;

        public override bool CanBeDetected(in ObjectDetectionContext context)
            => ObjectCanBeDetected?.Invoke(context) ?? true;

        protected override void OnObjectDetectionStart(in ObjectDetectionContext context)
        {
            base.OnObjectDetectionStart(context);
            ObjectDetectionStart?.Invoke(context);
        }

        protected override void OnObjectDetectionEnd(in ObjectDetectionContext context)
        {
            base.OnObjectDetectionEnd(context);
            ObjectDetectionEnd?.Invoke(context);
        }

        protected override void OnObjectDetectionFailed(in ObjectDetectionContext context)
        {
            base.OnObjectDetectionFailed(context);
            ObjectDetectionFailed?.Invoke(context);
        }

        protected override void OnObjectDetected(in ObjectDetectionContext context)
        {
            base.OnObjectDetected(context);
            ObjectDetected?.Invoke(context);
        }

        protected override void OnObjectGhostDetected(in ObjectDetectionContext context)
        {
            ObjectGhostDetected?.Invoke(context);
        }
    }
}