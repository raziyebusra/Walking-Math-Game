using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;

    public float moveSpeed = 5f;
    public float verticalSpeed = 2f;  // Constant vertical movement speed
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Handle movement
        float targetX = Input.GetAxis("Horizontal") * 2.0f; // Assuming input is always -1, 0, or 1
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);


        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Move the player
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
