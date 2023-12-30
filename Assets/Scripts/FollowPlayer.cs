using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, -10);

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + 4, player.transform.position.z - 20);
    }
}
