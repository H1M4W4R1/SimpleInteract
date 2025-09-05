using JetBrains.Annotations;

namespace Systems.SimpleInteract.Components.Abstract
{
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