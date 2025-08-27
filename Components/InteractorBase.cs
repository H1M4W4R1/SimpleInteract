using Systems.Detection2D.Components.Detectors.Abstract;
using Systems.Detection2D.Components.Objects.Abstract;
using Systems.SimpleInteract.Components.Abstract;
using UnityEngine;

namespace Systems.SimpleInteract.Components
{
    /// <summary>
    ///     Basic interactor component.
    /// </summary>
    public abstract class InteractorBase : DetectableObjectBase
    {
        /// <summary>
        ///     Interacts with all detected objects.
        /// </summary>
        /// <returns>Number of interactions performed</returns>
        [ContextMenu("Interact with all objects")]
        public int InteractAll()
        {
            int nInteractionsPerformed = 0;
            
            // Iterate over all detected objects
            for (int nInteractable = 0; nInteractable < DetectedBy.Count; nInteractable++)
            {
                // Get detector at index
                ObjectDetectorBase detectorTriggered = DetectedBy[nInteractable];
                
                // Skip if not interactable
                if (detectorTriggered is not IInteractable interactableObject) continue;
                
                // Handle interaction
                interactableObject.Interact(this);
                nInteractionsPerformed++;
            }
            
            return nInteractionsPerformed;
        }
        
        /// <summary>
        ///     Interacts with first detected object.
        /// </summary>
        /// <returns>True if interaction was performed, false otherwise</returns>
        [ContextMenu("Interact with first object")]
        public bool Interact()
        {
            if (DetectedBy.Count == 0) return false; 

            // Iterate over all detected objects
            for (int nInteractable = 0; nInteractable < DetectedBy.Count; nInteractable++)
            {
                // Get detector at index
                ObjectDetectorBase detectorTriggered = DetectedBy[nInteractable];
                
                // Skip if not interactable
                if (detectorTriggered is not IInteractable interactableObject) continue;
                
                // Handle interaction
                interactableObject.Interact(this);
                return true;
            }

            return false;
        }
    }
}