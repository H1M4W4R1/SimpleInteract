using JetBrains.Annotations;
using Systems.Detection2D.Components.Objects.Abstract;
using Systems.Interact2D.Components;

namespace Systems.Interact2D.Data
{
    /// <summary>
    ///     Represents interaction context between interactable object and interactor
    /// </summary>
    /// <typeparam name="TInteractor">Interactor type</typeparam>
    public readonly ref struct InteractionContext<TInteractor>
        where TInteractor : DetectableObjectBase
    {
        [NotNull] public readonly InteractableObjectBase<TInteractor> interactable;
        [NotNull] public readonly TInteractor interactor;

        public InteractionContext(
            [NotNull] InteractableObjectBase<TInteractor> interactable,
            [NotNull] TInteractor interactor)
        {
            this.interactable = interactable;
            this.interactor = interactor;
        }
    }
}