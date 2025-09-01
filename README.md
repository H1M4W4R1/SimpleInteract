<div align="center">
  <h1>SimpleInteract</h1>
  <!--<img src="https://github.com/H1M4W4R1/Detection2D/blob/master/Images/Screenshot0000.png" alt="Preview screenshot"/>-->
</div>

# About

SimpleInteract is a Unity3D system that creates interaction capabilities.

# Requirements

* Unity.Burst
* Unity.Collections
* Unity.Mathematics
* [**SimpleDetection Framework by H1M4W4R1**](https://github.com/H1M4W4R1/SimpleDetection)

# Usage

## Creating an interactable object

To create an interactable object you need to create a custom object class that inherits from
`InteractableObjectBase<TInteractor>`.

TInteractor should be a class that inherits from `DetectableObjectBase` and will be detected by
interactable object you created.

There are a few methods that will help you to handle interaction logic:

* `OnInteract(context)` - This method is called when the object is interacted with, must be implemented.
* `OnInteractFailed(context)` - This method is called when the object cannot be interacted with, recommended to
  implement.
* `OnInteractionZoneEnter()` - This method is called when the object enters the interaction zone, recommended for UI.
* `OnInteractionZoneExit()` - This method is called when the object exits the interaction zone, recommended for UI.

```csharp
    public sealed class ExampleInteractableObject : InteractableObjectBase<ExamplePlayerFlagObject>
    {
        protected override void OnInteract(InteractionContext<ExamplePlayerFlagObject> context)
        {
            Debug.Log("Interacted with player flag object");
        } 
    }
```

Beware that you also need to add any component that implements `IInteractableDetector` to your interactable object
to provide interaction zone.

## Creating an interactable player

You simply need to create a custom class that inherits from `InteractorBase<TSelf>`. It is heavily recommended
to have custom class for interactable detection and other detection logic to prevent further issues with handling things
such as player invisibility states which may require you to implement `ISupportGhostDetection` on your custom
interactable object abstraction layer.

Of course, you can also add custom detection events to this class.

```csharp
    public sealed class ExamplePlayerFlagObject : DetectableObjectBase<ExamplePlayerFlagObject>
    {
    }
```

## Interacting

When interact key is pressed you can interact with object by using `Interact(interactor)` method
of specific interactable object.

Also, interactor has `Interact()` method that allows to interact with first detected object (if any) and
`InteractAll()` method that allows to interact with all detected objects (if any).
