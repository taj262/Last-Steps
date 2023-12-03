using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 1f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[4];
    [SerializeField] private int _numFound;

    private void FixedUpdate()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
            _interactableMask);

        // check if something interactable is within range
        if (_numFound > 0 )
        {
            // get the interactable compontent of the game object found, ie. Teleporter, Chest
            IInteractable interactable = GetComponent<IInteractable>();
            
            // if within range of an interactable
            if ( interactable != null) 
            {
                
                // check if "e" key was pressed
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    // run the interact function within the interactable Game Object
                    interactable.Interact(this);
                }
                
            }
        }

        
    }
}
