using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WayPointManager : MonoBehaviour
{
    public List<Waypoint> waypoints = new List<Waypoint>();
    public GameObject button;
    public SO_Resource resource;

    public TextMeshProUGUI logCount;
    public TextMeshProUGUI stoneCount;
    public TextMeshProUGUI PlankCount;
    public TextMeshProUGUI clothCount;
    
    private int waypointCount;
    private int pointCounter;


    private void Start()
    {
        waypoints[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);
        waypointCount = waypoints.Count;
        foreach (var waypoint in waypoints)
        {
            waypoint.SetManager(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && pointCounter < waypointCount)
        {
            print("SPACE");
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        Destroy(waypoints[pointCounter].gameObject);
        int i = Random.Range(1, 5);
        switch (i)
        {
            case 1:
                resource.stone += 1;
                stoneCount.text = resource.stone.ToString();
                break;
            case 2:
                resource.plank++;
                PlankCount.text = resource.plank.ToString();
                break;
            case 3:
                resource.wood++;
                logCount.text = resource.wood.ToString();
                break;
            case 4:
                resource.cloth++;
                clothCount.text = resource.cloth.ToString();
                break;
        }
        
        
        pointCounter++;
        if (pointCounter != waypointCount)
        {
            waypoints[pointCounter].GetComponent<Image>().color = new Color(255, 255, 255, 100);
        }
    }

    public void ActivateButton()
    {
        button.SetActive(true);
    }

    public void OnButtonPress()
    {
        button.SetActive(false);
        NextWaypoint();
    }
}
