using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool IsActive { get; private set; }
    private WayPointManager _wayPointManager;
    public void Activate()
    {
        IsActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsActive)
        {
            _wayPointManager.ActivateButton();
        }
    }

    public void SetManager(WayPointManager manager)
    {
        _wayPointManager = manager;
    }
}
