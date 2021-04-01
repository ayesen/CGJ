using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtStop : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stop"))
        {
            GameManager.stopAt = this.transform.position;
        }
    }
}
