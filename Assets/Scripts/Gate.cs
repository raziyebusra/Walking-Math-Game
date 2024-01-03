using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameManager gameManager;  // Reference to the GameManager

    // Set the GameManager reference
    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the TextMeshPro component in the gate object
            TextMeshPro gateText = GetComponentInChildren<TextMeshPro>();

            // Parse the text to get the score value
            if (int.TryParse(gateText.text, out int scoreDelta))
            {
                // Update the player's score in the GameManager
                gameManager.UpdatePlayerScore(scoreDelta);
            }

            Destroy(gameObject);
        }
    }
}