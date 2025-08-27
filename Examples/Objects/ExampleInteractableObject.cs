using Systems.SimpleInteract.Components;
using Systems.SimpleInteract.Data;
using Systems.SimpleInteract.Examples.Interactors;
using UnityEngine;

namespace Systems.SimpleInteract.Examples.Objects
{
    /// <summary>
    ///     Handles interaction with player flag object
    /// </summary>
    public sealed class ExampleInteractableObject : InteractableObjectBase<ExamplePlayerFlagObject>
    {
        [ContextMenu("Test interaction")]
        private void InteractAsFirstInteractor()
        {
            if (Interactors.Count == 0) return;
            Interact(Interactors[0]);
        }
        
        protected override void OnInteract(InteractionContext<ExamplePlayerFlagObject> context)
        {
            Debug.Log("Interacted with player flag object");
            Destroy(gameObject);
        }

        protected override void OnInteractFailed(InteractionContext<ExamplePlayerFlagObject> context)
        {
            Debug.Log("Failed to interact with player flag object");
        }

        protected override void OnInteractionZoneEnter(ExamplePlayerFlagObject obj)
        {
            Debug.Log("Player flag object entered interaction zone");
        }

        protected override void OnInteractionZoneExit(ExamplePlayerFlagObject obj)
        {
            Debug.Log("Player flag object exited interaction zone");
        }
    }
}