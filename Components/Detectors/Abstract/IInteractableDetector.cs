namespace Systems.SimpleInteract.Components.Detectors.Abstract
{
    /// <summary>
    ///     Interactable detector interface to support different detectors across 2D and 3D space.
    /// </summary>
    public interface IInteractableDetector
    {
        internal event Delegates.ObjectDetectedHandle ObjectDetected;
        internal event Delegates.ObjectDetectionFailedHandle ObjectDetectionFailed;
        internal event Delegates.ObjectDetectionEndHandle ObjectDetectionEnd;
        internal event Delegates.ObjectDetectionStartHandle ObjectDetectionStart;
        internal event Delegates.ObjectGhostDetectedHandle ObjectGhostDetected;
        internal event Delegates.CanBeDetectedHandle ObjectCanBeDetected;
        
    }
}