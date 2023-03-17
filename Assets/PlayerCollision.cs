using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"Waypoint"))
        {
            var wayPoint = other.GetComponent<Waypoint>();
            if (wayPoint.IsActive)
            {
                //Enable scene transition button
            }
        }
    }
}
