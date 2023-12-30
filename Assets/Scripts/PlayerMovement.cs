using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sideMoveDistance = 2f; // Distance the player can move to the sides
    public Transform groundCheck;
    public LayerMask groundLayer;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded)
        {
            // Handle player movement
            HandleSwipeInput();
            HandleArrowKeyInput();

            // Apply gravity to keep the player grounded
            if (playerVelocity.y < 0)
                playerVelocity.y = -2f;

            // Move the player
            characterController.Move(playerVelocity * Time.deltaTime);
        }
    }

    void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the swipe distance
                float swipeDelta = touch.deltaPosition.x / Screen.width;

                // Move the player based on swipe
                MovePlayer(swipeDelta);
            }
        }
    }

    void HandleArrowKeyInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // Move the player based on arrow keys
            MovePlayer(horizontalInput);
        }
    }

    void MovePlayer(float input)
    {
        // Calculate the target position
        float targetX = Mathf.Clamp(transform.position.x + input * sideMoveDistance, -sideMoveDistance, sideMoveDistance);

        // Set the player's position directly
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
