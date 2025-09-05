using JetBrains.Annotations;
using Systems.SimpleInteract.Components;

namespace Systems.SimpleInteract.Data
{
    /// <summary>
    ///     Represents interaction context between interactable object and interactor
    /// </summary>
    public readonly ref struct InteractionContext
    {
        [NotNull] public readonly InteractableObjectBase interactable;
        [NotNull] public readonly InteractorBase interactor;

        public InteractionContext(
            [NotNull] InteractableObjectBase interactable,
            [NotNull] InteractorBase interactor)
        {
            this.interactable = interactable;
            this.interactor = interactor;
        }
    }
}