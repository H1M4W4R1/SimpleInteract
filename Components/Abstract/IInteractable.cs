using JetBrains.Annotations;
using Systems.SimpleCore.Operations;
using Systems.SimpleCore.Utility.Enums;

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
        /// <param name="actionSource">Source of action</param>
        public OperationResult Interact([NotNull] InteractorBase interactor, ActionSource actionSource = ActionSource.External);
    }
}