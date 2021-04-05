using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public float offset = 5f;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+offset, player.transform.position.y, transform.position.z);
    }
}
