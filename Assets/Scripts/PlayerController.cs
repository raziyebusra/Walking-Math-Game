using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float horizontalSpeed = 8f;
    public float xRange = 2.5f;

    public bool isGameOver;

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * horizontalSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed);
    }
}
