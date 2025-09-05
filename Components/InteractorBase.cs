using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Components.Detectors.Abstract;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleInteract.Components.Detectors.Abstract;
using Systems.SimpleInteract.Data;
using Systems.SimpleInteract.Operations;
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

#if UNITY_EDITOR
        [ContextMenu("Interact with all objects")] private void InteractWithAllObjectEditorFunc()
        {
            if (OperationResult.AreSimilar(InteractAll(), InteractOperations.NoObjectsInRange()))
                Debug.LogError("Interact failed: No objects in range");
        }
#endif

        /// <summary>
        ///     Interacts with all detected objects.
        /// </summary>
        /// <returns>Number of interactions performed</returns>
        public OperationResult<int> InteractAll()
        {
            int nInteractionsPerformed = 0;

            // Iterate over all detected objects
            for (int nInteractable = 0; nInteractable < DetectedBy.Count; nInteractable++)
            {
                // Get detector at index
                ObjectDetectorBase detectorTriggered = DetectedBy[nInteractable];

                // Skip if not interactable
                if (detectorTriggered is not IInteractableDetector detector) continue;

                if (detector is not Component component) continue;

                // Get interactable object
                InteractableObjectBase interactableObject = component.GetComponent<InteractableObjectBase>();

                // Handle interaction
                interactableObject.Interact(this);
                nInteractionsPerformed++;
            }

            // Return result
            if (nInteractionsPerformed > 0)
                return InteractOperations.Interacted().WithData(nInteractionsPerformed);

            return InteractOperations.NoObjectsInRange().WithData(0);
        }

#if UNITY_EDITOR
        [ContextMenu("Interact with first object")] private void InteractWithFirstObjectEditorFunc()
        {
            if (OperationResult.AreSimilar(Interact(), InteractOperations.NoObjectsInRange()))
                Debug.LogError("Interact failed: No objects in range");
        }
#endif


        /// <summary>
        ///     Interacts with first detected object.
        /// </summary>
        public OperationResult Interact()
        {
            if (DetectedBy.Count == 0) return InteractOperations.NoObjectsInRange();

            // Iterate over all detected objects
            for (int nInteractable = 0; nInteractable < DetectedBy.Count; nInteractable++)
            {
                // Get detector at index
                ObjectDetectorBase detectorTriggered = DetectedBy[nInteractable];

                // Skip if not interactable
                if (detectorTriggered is not IInteractableDetector detector) continue;

                if (detector is not Component component) continue;

                // Get interactable object
                InteractableObjectBase interactableObject = component.GetComponent<InteractableObjectBase>();

                // Handle interaction
                return interactableObject.Interact(this);
            }

            return InteractOperations.NoObjectsInRange();
        }
    }
}