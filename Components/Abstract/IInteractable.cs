using JetBrains.Annotations;

namespace Systems.Interact2D.Components.Abstract
{
    /// <summary>
    ///     Accessor for interaction logic.
    /// </summary>
    public interface IInteractable<in TInteractor> : IInteractable
    {
        /// <summary>
        ///     Interacts with this object.
        /// </summary>
        /// <param name="interactor">Interactor that is attempting to interact with this object</param>
        public void Interact([NotNull] TInteractor interactor);

        // Jump into local implementation aka. black magic fuckery
        void IInteractable.Interact(InteractorBase interactor)
        {
            if (interactor is not TInteractor validInteractor) return;
            Interact(validInteractor);
        }
    }
    
    /// <summary>
    ///     Accessor for interaction logic.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        ///     Interacts with this object.
        /// </summary>
        /// <param name="interactor">Interactor that is attempting to interact with this object</param>
        public void Interact([NotNull] InteractorBase interactor);
    }
}