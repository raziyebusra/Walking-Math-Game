using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Reference to the character controller
    public float speed = 5f;              // Character's forward movement speed
    float targetXPosition = 0f;           // Variable to store the target x-position

    void Update()
    {
        if (!FinishScript.Instance.isGameFinished)
        {
            // Continuous forward movement
            Vector3 moveDirection = transform.forward * speed * Time.deltaTime;
            controller.Move(moveDirection);

            // Handle side-to-side movement with key presses
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                targetXPosition = -2f;  // Set target position to -2 on x-axis
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                targetXPosition = 2f;  // Set target position to +2 on x-axis
            }

            // Move towards the target position smoothly, ensuring it's within -2 and +2
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(targetXPosition, -2f, 2f), transform.position.y, transform.position.z), Time.deltaTime * speed * 6);
        }
    }
}
