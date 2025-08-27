using Systems.Detection2D.Components.Detectors.Abstract;
using Systems.Detection2D.Components.Objects.Abstract;
using Systems.Interact2D.Components.Abstract;
using UnityEngine;

namespace Systems.Interact2D.Components
{
    /// <summary>
    ///     Basic interactor component.
    /// </summary>
    public abstract class InteractorBase : DetectableObjectBase
    {
        /// <summary>
        ///     Interacts with first detected object.
        /// </summary>
        [ContextMenu("Interact with first object")]
        public void Interact()
        {
            if (DetectedBy.Count == 0) return;

            for (int nInteracable = 0; nInteracable < DetectedBy.Count; nInteracable++)
            {
                // Get detector at index
                ObjectDetectorBase detectorTriggered = DetectedBy[nInteracable];
                
                // Skip if not interactable
                if (detectorTriggered is not IInteractable interactableObject) continue;
                
                // Handle interaction
                interactableObject.Interact(this);
            }
        }
    }
}