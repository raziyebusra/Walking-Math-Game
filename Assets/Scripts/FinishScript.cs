using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public static FinishScript Instance;  // Singleton instance
    public TMP_Text targetNumberText;
    public bool isGameFinished = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sensor triggered by: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            isGameFinished = true;
            // Get the target number from the TextMeshPro Text
            int targetNumber;
            if (int.TryParse(targetNumberText.text, out targetNumber))
            {
                // Check if the player's score matches the target number
                if (GameManager.Instance != null && GameManager.Instance.playerScore == targetNumber)
                {
                    // Player wins
                    GameManager.Instance.HandleGameFinish(true);

                }
                else
                {
                    // Player loses
                    GameManager.Instance.HandleGameFinish(false);
                }

                // Set the game as finished when the player collides with the sensor
            }
        }
    }
}
