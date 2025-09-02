using Systems.SimpleDetection.Components.Detectors.Base;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleDetection.Data;
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

        public override bool CanBeDetected(ObjectDetectionContext context)
            => ObjectCanBeDetected?.Invoke(context.detectableObject) ?? true;

        protected override void OnObjectDetectionStart(DetectableObjectBase obj)
        {
            base.OnObjectDetectionStart(obj);
            ObjectDetectionStart?.Invoke(obj);
        }

        protected override void OnObjectDetectionEnd(DetectableObjectBase obj)
        {
            base.OnObjectDetectionEnd(obj);
            ObjectDetectionEnd?.Invoke(obj);
        }

        protected override void OnObjectDetectionFailed(DetectableObjectBase obj)
        {
            base.OnObjectDetectionFailed(obj);
            ObjectDetectionFailed?.Invoke(obj);
        }

        protected override void OnObjectDetected(DetectableObjectBase obj)
        {
            base.OnObjectDetected(obj);
            ObjectDetected?.Invoke(obj);
        }

        protected override void OnObjectGhostDetected(DetectableObjectBase obj)
        {
            ObjectGhostDetected?.Invoke(obj);
        }
    }
}