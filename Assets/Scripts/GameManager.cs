using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject[] gates;
    [SerializeField] private int score;
    public TextMesh scoreText;

    public TextMeshProUGUI gateText;

    void Start()
    {
        if (gates != null && gates.Length > 0)
        {
            DetermineGatePositionsAndText();
        }
        else
        {
            Debug.LogError("Gates array is not properly set in the Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = " " + score;
    }
    void DetermineGatePositionsAndText()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            // Determine position based on index

            Vector3 gatePosition0 = new Vector3(-1f, 4.5f, -19f);
            Vector3 gatePosition1 = new Vector3(3f, 4.5f, -19f);
            Vector3 gatePosition2 = new Vector3(-1f, 4.5f, -4f);
            Vector3 gatePosition3 = new Vector3(3f, 4.5f, -4f);
            Vector3 gatePosition4 = new Vector3(-1f, 4.5f, 11f);
            Vector3 gatePosition5 = new Vector3(3f, 4.5f, 11f);

            gates[0].transform.position = gatePosition0;
            gates[1].transform.position = gatePosition1;
            gates[2].transform.position = gatePosition2;
            gates[3].transform.position = gatePosition3;
            gates[4].transform.position = gatePosition4;
            gates[5].transform.position = gatePosition5;

        }
    }
}
