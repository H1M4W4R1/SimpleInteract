using Systems.Interact2D.Components;
using Systems.Interact2D.Data;
using UnityEngine;

namespace Systems.Interact2D.Examples
{
    /// <summary>
    ///     Handles interaction with player flag object
    /// </summary>
    public sealed class ExampleInteractableObject : InteractableObjectBase<ExamplePlayerFlagObject>
    {
        protected override void OnInteract(InteractionContext<ExamplePlayerFlagObject> context)
        {
            Debug.Log("Interacted with player flag object");
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