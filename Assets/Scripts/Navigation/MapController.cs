using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private float latWest = 5.925280987934647f;
    [SerializeField] private float latEast = 5.969226300434647f;

    [SerializeField] private float longNorth = 52.17235480226429f;
    [SerializeField] private float longSouth = 52.14539549491262f;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private RectTransform mapWindow;

    private GameObject _playerInstance;
    private RectTransform _instancePosition;
    
    private float _latScale;
    private float _longScale;

    private float _playerLocationX =  0.03562539f;
    private float _playerLocationY = 0.009716596f;

    [Header("Test Vars")] 
    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _latScale = latEast - latWest;
        _longScale = longNorth - longSouth;
        print("This map is: " + _latScale + " wide and: " + _longScale + " long");
        mapWindow = this.GetComponent<RectTransform>();
        _playerInstance = Instantiate(playerObject, transform);
        _instancePosition = _playerInstance.GetComponent<RectTransform>();
        RenderPlayer();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _playerLocationX += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            _playerLocationY += (Input.GetAxisRaw("Vertical") * speed / 2 * Time.deltaTime) * -1;
        }
        
        RenderPlayer();
    }

    private void RenderPlayer()
    {
        var rect = mapWindow.rect;
        var xPos = Mathf.Clamp(((_playerLocationX / _latScale) * rect.width), 0f, 1024f);
        var yPos = Mathf.Clamp(((((_playerLocationY / _longScale) * -1) * rect.height)), -1024f, 0f);
        //print(xPos + ", " + yPos);
        print(_playerLocationX + ", " + _playerLocationY);
        
        var newPos = new Vector3(xPos, yPos, 0);
        _instancePosition.anchoredPosition = newPos;
    }
}
