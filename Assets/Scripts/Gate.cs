using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int pointValue;
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
