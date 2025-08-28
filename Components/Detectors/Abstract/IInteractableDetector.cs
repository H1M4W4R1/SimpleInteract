namespace Systems.SimpleInteract.Components.Detectors.Abstract
{
    /// <summary>
    ///     Interactable detector interface to support different detectors across 2D and 3D space.
    /// </summary>
    public interface IInteractableDetector
    {
        public event Delegates.ObjectDetectedHandle ObjectDetected;
        public event Delegates.ObjectDetectionFailedHandle ObjectDetectionFailed;
        public event Delegates.ObjectDetectionEndHandle ObjectDetectionEnd;
        public event Delegates.ObjectDetectionStartHandle ObjectDetectionStart;
        public event Delegates.ObjectGhostDetectedHandle ObjectGhostDetected;
        public event Delegates.CanBeDetectedHandle ObjectCanBeDetected;
        
    }
}