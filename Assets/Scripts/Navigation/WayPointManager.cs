using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class WayPointManager : MonoBehaviour
{
    public List<Waypoint> waypoints = new List<Waypoint>();
    private int waypointCount;
    private int pointCounter;


    private void Start()
    {
        waypoints[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);
        waypointCount = waypoints.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && pointCounter < waypointCount)
        {
            print("SPACE");
            Destroy(waypoints[pointCounter].gameObject);
            pointCounter++;
            if (pointCounter != waypointCount)
            {
                waypoints[pointCounter].GetComponent<Image>().color = new Color(255, 255, 255, 100);
            }
        }
    }
}
