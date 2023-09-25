using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // New input system
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour, IDamageable
{
    // multipliers
    [Range(0.01f, 1.0f), Tooltip("How fast to rotate our player to face a direction:\n 1 = instant, 0 = no rotation.")]
    public float rotationSpeed = 0.1f;

    [Tooltip("Speed of the player in units per second")]
    public float speed;

    
    // inputs
    Vector2 move, mouseLook;
    Vector3 rotationTarget;
    bool rightMouseHeld;
    bool leftMouseHeld;

    // components
    CharacterController characterController;

    // private constants
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    float velocity;

    // public constants
    public float GravityMultiplier = 3f;
    Gun PlayerGun;

    public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // get WASD input
    public void OnMove(InputAction.CallbackContext context)
    {
        // vector2 of WASD input
        move = context.ReadValue<Vector2>();
    }

    // get mouse position for player to look at
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        // vector2 of mouse world position
        mouseLook = context.ReadValue<Vector2>();
    }

    // get input right mouse button
    public void OnRightMouseButton(InputAction.CallbackContext context)
    {
        // bool if RMB down
        rightMouseHeld = context.ReadValue<float>() > 0;
    }

    // get input left mouse button
    public void OnLeftMouseButton(InputAction.CallbackContext context)
    {
        leftMouseHeld = context.ReadValue<float>() > 0;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        PlayerGun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightMouseHeld)
        {
            // shoot a raycast
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);

            // if that raycast hit somehting
            if (Physics.Raycast(ray, out hit))
            {
                // record that point
                rotationTarget = hit.point;
            }

            // move player and aim independantly
            MovePlayerWithAim();

        }
        else
        {
            // move normaly
            MovePlayer();
        }


    }
    
    public void MovePlayer()
    {
        // get x and y from our input system
        Vector3 movementDirection = new Vector3(move.x, 0f, move.y);

        // move and look in the same direction
        MovementHelper(movementDirection, movementDirection, movementDirection, rotationSpeed);

    }

    public void MovePlayerWithAim()
    {
        // get direction to the player
        Vector3 lookPos = rotationTarget - transform.position;

        // ignore looking up or down
        lookPos.y = 0f;

        // get aim input direction
        Vector3 lookDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.y);

        // get x and y from our input system
        Vector3 movementDirection = new Vector3(move.x, 0f, move.y);
        
        // move and look in different directions
        MovementHelper(movementDirection, lookDirection, lookPos, 1);

        // shoot if left mouse held
        if (leftMouseHeld)
        {
            if (PlayerGun != null)
            {
                PlayerGun.FireBullet();
            }
        }
    }

    void MovementHelper(Vector3 movementDirection, Vector3 input, Vector3 lookAt, float rotationSpeed)
    {

        // if we have some input
        if (input != Vector3.zero)
        {
            // rotate towards the direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookAt), rotationSpeed);
        }

        // add gravity
        if (characterController.isGrounded && velocity < 0)
        {
            // Intuitivly should be 0, but better results with -1
            velocity = -1.0f;
        }
        else
        {
            velocity += gravityValue * GravityMultiplier * Time.deltaTime;
        }

        movementDirection.y = velocity;

        // move our players position in the direction of movement with respect to time and speed
        characterController.Move(movementDirection * speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
