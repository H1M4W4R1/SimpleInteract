using System.Collections.Generic;
using Systems.SimpleDetection.Components.Objects.Abstract;
using Systems.SimpleInteract.Components.Abstract;
using Systems.SimpleInteract.Components.Detectors.Abstract;
using Systems.SimpleInteract.Data;
using UnityEngine;

namespace Systems.SimpleInteract.Components
{
    /// <summary>
    ///     Represents object that can be interacted with in 2D space
    /// </summary>
    /// <remarks>
    ///     <see cref="TInteractor"/> is provided with high intention to reduce performance issues
    ///     when having a lot of interaction objects on the scene - it allows to reduce raycast amount
    ///     by ignoring objects that are not e.g. player or other interactors.
    ///     For reference see <see cref="CanBeDetected"/> method.
    /// </remarks>
    [RequireComponent(typeof(IInteractableDetector))]
    public abstract class InteractableObjectBase<TInteractor> : MonoBehaviour, IInteractable<TInteractor>
        where TInteractor : InteractorBase<TInteractor>
    {
        /// <summary>
        ///     Detector linked to this object
        /// </summary>
        private IInteractableDetector _detector;
        
        /// <summary>
        ///     Cache of all interactors that can interact with this object
        ///     at current frame
        /// </summary>
        private readonly List<TInteractor> _interactors = new();

        /// <summary>
        ///     All interactors that are able to interact at current frame
        /// </summary>
        public IReadOnlyList<TInteractor> Interactors => _interactors;

        /// <summary>
        ///     Check if this object can be interacted with
        /// </summary>
        /// <returns>True if this object can be interacted with</returns>
        public virtual bool CanBeInteractedWith(InteractionContext<TInteractor> context) => true;

        /// <summary>
        ///     Attempts to interact with this object using given interactor.
        ///     This method is the single entry point for all interaction logic.
        ///
        ///     If this object can be interacted with, then <see cref="OnInteract"/> is called,
        ///     otherwise <see cref="OnInteractFailed"/> is called.
        /// </summary>
        /// <param name="interactor">Object that is attempting to interact with this object</param>
        public void Interact(TInteractor interactor)
        {
            // Create context
            InteractionContext<TInteractor> context = new(this, interactor);

            // Check if object can be interacted with
            if (CanBeInteractedWith(context) && interactor.CanInteract(context))
                OnInteract(context);
            else
                OnInteractFailed(context);
        }

        /// <summary>
        ///     Called when interaction with this object has failed.
        ///     This event is called after <see cref="CanBeInteractedWith"/> has returned false.
        /// </summary>
        /// <param name="context">Context of interaction</param>
        protected virtual void OnInteractFailed(InteractionContext<TInteractor> context)
        {
        }

        /// <summary>
        ///     Called when interaction with this object has succeeded.
        ///     This event is called after <see cref="CanBeInteractedWith"/> has returned true.
        /// </summary>
        /// <param name="context">Context of interaction</param>
        protected abstract void OnInteract(InteractionContext<TInteractor> context);

        /// <summary>
        ///     Called when object enters interaction zone.
        /// </summary>
        /// <param name="obj">Object that entered interaction zone</param>
        protected virtual void OnInteractionZoneEnter(TInteractor obj)
        {
        }

        /// <summary>
        ///     Called when object exits interaction zone.
        /// </summary>
        /// <param name="obj">Object that exited interaction zone</param>
        protected virtual void OnInteractionZoneExit(TInteractor obj)
        {
        }

#region Unity Lifecycle

        protected void Awake()
        {
           _detector = GetComponent<IInteractableDetector>();
           _detector.ObjectCanBeDetected += CanBeDetected;
           _detector.ObjectDetectionStart += OnObjectDetectionStart;
           _detector.ObjectDetectionEnd += OnObjectDetectionEnd;
           _detector.ObjectDetectionFailed += OnObjectDetectionFailed;
           _detector.ObjectDetected += OnObjectDetected;
           _detector.ObjectGhostDetected += OnObjectGhostDetected;
        }

        protected void OnDestroy()
        {
            _detector.ObjectCanBeDetected -= CanBeDetected;
            _detector.ObjectDetectionStart -= OnObjectDetectionStart;
            _detector.ObjectDetectionEnd -= OnObjectDetectionEnd;
            _detector.ObjectDetectionFailed -= OnObjectDetectionFailed;
            _detector.ObjectDetected -= OnObjectDetected;
            _detector.ObjectGhostDetected -= OnObjectGhostDetected;
        }

#endregion

#region IInteractableDetector Handlers

        /// <summary>
        ///     Checks if object can be detected by this interactor.
        ///     Used for performance optimization.
        /// </summary>
        /// <param name="obj">Object to check</param>
        public virtual bool CanBeDetected(DetectableObjectBase obj) => obj is TInteractor;

        
        protected virtual void OnObjectDetectionStart(DetectableObjectBase obj)
        {
            if (obj is TInteractor interactor) OnInteractionZoneEnter(interactor);
        }

        protected virtual void OnObjectDetectionEnd(DetectableObjectBase obj)
        {
            if (obj is TInteractor interactor) OnInteractionZoneExit(interactor);
        }

        protected virtual void OnObjectDetectionFailed(DetectableObjectBase obj)
        {
            if (obj is TInteractor detectableObjectBase)
                _interactors.RemoveAll(o => ReferenceEquals(o, detectableObjectBase));
        }

        protected virtual void OnObjectDetected(DetectableObjectBase obj)
        {
            // Skip if object is not of type TDetectableObjectBase
            if (obj is not TInteractor detectableObjectBase) return;

            // Add interactor if it is not already in the list
            if (!_interactors.Contains(detectableObjectBase)) _interactors.Add(detectableObjectBase);
        }

        protected virtual void OnObjectGhostDetected(DetectableObjectBase obj)
        {
            // Safety fallback, technically ghosts should not be supported by interactable objects,
            // but we keep it just in case somebody decides otherwise and adds ghost support to object class.
            OnObjectDetected(obj);
        }

#endregion
    }
}