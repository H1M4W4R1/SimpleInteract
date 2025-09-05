using System.Collections.Generic;
using JetBrains.Annotations;
using Systems.SimpleInteract.Data;

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
        /// <typeparam name="TInteractor">Type of interactor</typeparam>
        /// <param name="interactor">Interactor that is attempting to interact with this object</param>
        public void InteractWith<TInteractor>([NotNull] TInteractor interactor)
            where TInteractor : InteractorBase
        {
            // TODO: Implement this!
        }
    }
}