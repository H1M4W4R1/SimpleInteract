using System.Collections.Generic;
using JetBrains.Annotations;
using Systems.SimpleInteract.Data;

namespace Systems.SimpleInteract.Components.Abstract
{
    /// <summary>
    ///     Accessor for interaction logic.
    /// </summary>
    public interface IInteractable<in TInteractorSealed> : IInteractable
        where TInteractorSealed : InteractorBase<TInteractorSealed>, new()
    {
        /// <summary>
        ///     Interacts with this object.
        /// </summary>
        /// <param name="interactor">Interactor that is attempting to interact with this object</param>
        public void Interact([NotNull] TInteractorSealed interactor);
    }

    /// <summary>
    ///     Accessor for interaction logic.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        ///     Interacts with this object.
        /// </summary>
        /// <typeparam name="TInteractor">Type of interactor</typeparam>
        /// <param name="interactor">Interactor that is attempting to interact with this object</param>
        public void InteractWith<TInteractor>([NotNull] TInteractor interactor)
            where TInteractor : InteractorBase<TInteractor>, new()
        {
            if (this is IInteractable<TInteractor> directlyInteractable) directlyInteractable.Interact(interactor);
        }
    }
}