using JetBrains.Annotations;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleInteract.Components;

namespace Systems.SimpleInteract.Data
{
    /// <summary>
    ///     Represents interaction context between interactable object and interactor
    /// </summary>
    /// <typeparam name="TInteractorSealed">Interactor type</typeparam>
    public readonly ref struct InteractionContext<TInteractorSealed>
        where TInteractorSealed : InteractorBase<TInteractorSealed>, new()
    {
        [NotNull] public readonly InteractableObjectBase<TInteractorSealed> interactable;
        [NotNull] public readonly TInteractorSealed interactor;

        public InteractionContext(
            [NotNull] InteractableObjectBase<TInteractorSealed> interactable,
            [NotNull] TInteractorSealed interactor)
        {
            this.interactable = interactable;
            this.interactor = interactor;
        }
    }
}