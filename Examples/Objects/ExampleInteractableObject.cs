using Systems.SimpleCore.Operations;
using Systems.SimpleDetection.Data;
using Systems.SimpleInteract.Components;
using Systems.SimpleInteract.Data;
using Systems.SimpleInteract.Examples.Interactors;
using Systems.SimpleInteract.Operations;
using UnityEngine;

namespace Systems.SimpleInteract.Examples.Objects
{
    /// <summary>
    ///     Handles interaction with player flag object
    /// </summary>
    public sealed class ExampleInteractableObject : InteractableObjectBase
    {
        [ContextMenu("Test interaction")] private void InteractAsFirstInteractor()
        {
            if (Interactors.Count == 0) return;
            Interact(Interactors[0]);
        }

        public override OperationResult CanBeDetected(in ObjectDetectionContext context)
        {
            if (context.detectableObject is not ExamplePlayerFlagObject) return InteractOperations.Denied();
            return InteractOperations.Permitted();
        }

        public override OperationResult CanBeInteractedWith(InteractionContext context)
        {
            if (context.interactor is not ExamplePlayerFlagObject) return InteractOperations.Denied();
            return InteractOperations.Permitted();
        }

        protected override void OnInteract(
            in InteractionContext interactionContext,
            in OperationResult interactCapabilityResult)
        {
            Debug.Log("Interacted with player flag object");
            Destroy(gameObject);
        }

        protected override void OnInteractFailed(
            in InteractionContext interactionContext,
            in OperationResult interactCapabilityResult)
        {
            Debug.Log("Failed to interact with player flag object");
        }

        protected override void OnInteractionZoneEnter(InteractorBase interactorBase)
        {
            Debug.Log("Player flag object entered interaction zone");
        }

        protected override void OnInteractionZoneExit(InteractorBase interactorBase)
        {
            Debug.Log("Player flag object exited interaction zone");
        }
    }
}