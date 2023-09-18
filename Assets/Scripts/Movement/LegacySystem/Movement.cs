using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("Units per second")]
    public float playerSpeed = 5.0f;

    [Tooltip("Degrees per second")]
    public int rotationSpeed = 360;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        // gets input from hori and vert axis set in: Edit > ProjectSettings > InputManager
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        // move the players position according to time and speed
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);

        // if we are not sitting still
        if (moveDirection != Vector3.zero)
        {
            // Set a rotation towards the movement direction on the axis of world up
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            // rotate from current rotation to our needed roatation by some degree speed with respect to time
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            
        }

        // move player down by adding gravity to velocity
        playerVelocity.y += gravityValue * Time.deltaTime;
        // move player using character controller
        controller.Move(playerVelocity * Time.deltaTime);
    }
}