using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Components.Detectors.Abstract;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleInteract.Components.Abstract;
using Systems.SimpleInteract.Data;
using UnityEngine;

namespace Systems.SimpleInteract.Components
{
    /// <summary>
    ///     Basic interactor component.
    /// </summary>
    public abstract class InteractorBase : DetectableObjectBase
    {
        /// <summary>
        ///     Checks if this interactor can interact with given interactable object.
        /// </summary>
        public virtual OperationResult CanInteract(InteractionContext context) =>
            context.interactable.CanBeInteractedWith(context);
        
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
                interactableObject.InteractWith(this);
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
                interactableObject.InteractWith(this);
                return true;
            }

            return false;
        }
    }
}