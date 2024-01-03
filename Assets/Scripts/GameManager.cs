using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject gatePrefab;  // Prefab for the gate
    public Material gateBlueMaterial; // Material for gates with even numbers
    public TextMeshPro playerScoreText;  // Reference to the player's score text
    private int playerScore;  // Player's score

    public GameObject gatesParent;  // Reference to the empty 3D object for gates

    void Start()
    {
        playerScore = 0;

        UpdatePlayerScoreText();

        // Create an empty 3D object to act as the parent of the gates
        gatesParent = new GameObject("GatesParent");

        // Create an array to store the instantiated gates
        GameObject[] gates = new GameObject[6];

        // Spawn and set positions/texts for each gate
        for (int i = 0; i < gates.Length; i++)
        {
            Vector3 gatePosition = DetermineGatePosition(i);
            GameObject gate = Instantiate(gatePrefab, gatePosition, Quaternion.identity, gatesParent.transform);
            gates[i] = gate;

            // Access TextMeshPro component in child object
            TextMeshPro textMeshPro = gate.GetComponentInChildren<TextMeshPro>();

            // Assign specific text based on index
            switch (i)
            {
                case 0:
                    textMeshPro.text = "+8";
                    break;
                case 1:
                    textMeshPro.text = "+5";
                    break;
                case 2:
                    textMeshPro.text = "+15";
                    break;
                case 3:
                    textMeshPro.text = "+30";
                    break;
                case 4:
                    textMeshPro.text = "+4";
                    break;
                case 5:
                    textMeshPro.text = "-7";
                    break;
                default:
                    textMeshPro.text = "Default Text";
                    break;
            }

            // Apply blue material to gates with even numbers
            if (i % 2 == 0)
            {
                Renderer gateRenderer = gate.GetComponent<Renderer>();
                if (gateRenderer != null)
                {
                    gateRenderer.material = gateBlueMaterial;
                }
            }
            // Add a Gate script component to each gate
            Gate gateScript = gate.AddComponent<Gate>();
            gateScript.SetGameManager(this);

        }
    }

    // Determine position based on index
    Vector3 DetermineGatePosition(int index)
    {
        switch (index)
        {
            case 0:
                return new Vector3(-2.71f, 1f, -45f);
            case 1:
                return new Vector3(1.29f, 1f, -45f);
            case 2:
                return new Vector3(-2.7f, 1f, -30f);
            case 3:
                return new Vector3(1.29f, 1f, -30f);
            case 4:
                return new Vector3(-2.7f, 1f, -15f);
            case 5:
                return new Vector3(1.29f, 1f, -15f);
            default:
                return Vector3.zero;  // Default position if index is out of range
        }
    }
    // Update player's score and the displayed text
    public void UpdatePlayerScore(int scoreDelta)
    {
        playerScore += scoreDelta;
        UpdatePlayerScoreText();
    }

    // Update the displayed player's score text
    void UpdatePlayerScoreText()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = "" + playerScore;
        }
    }
}
