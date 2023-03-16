using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using TMPro;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    
    public LocationInfo LocationInfo;
    public TextMeshProUGUI text;
    
    private bool _locationTrackerActive;
    private bool _hasFineLocationPermission;

    private float lastLatitude;
    private float lastLongitude;
    
    
        private IEnumerator Start()
    {
        _hasFineLocationPermission = Permission.HasUserAuthorizedPermission(Permission.FineLocation);
        
        if (_hasFineLocationPermission)
        {
            StartCoroutine(BootLocationTracker());
            yield break;
        }

        var permissionCallbacks = new PermissionCallbacks();
        
        permissionCallbacks.PermissionGranted += s => { StartCoroutine(BootLocationTracker()); };
        permissionCallbacks.PermissionDenied += s => { print("Location was not granted"); };
        permissionCallbacks.PermissionDeniedAndDontAskAgain += s => { print("Location permanently denied"); };

        Permission.RequestUserPermission(Permission.FineLocation, permissionCallbacks);
    }

    private IEnumerator BootLocationTracker()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        
        Input.location.Start();

        text.text = Input.location.status.ToString();
        
        var maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        
        if (maxWait < 1)
        {
            text.text = "Timed out";
            yield break;
        }
        
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            text.text = "Unable to determine device location";
            yield break;
        }

        lastLatitude = Input.location.lastData.latitude;
        lastLongitude = Input.location.lastData.longitude;
        
        // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
        text.text = "Lat: " + lastLatitude + " " + "Long: " + lastLongitude;

        InvokeRepeating(nameof(UpdateLoc), 0, 1f);
    }

    private void UpdateLoc()
    {
        lastLatitude = Input.location.lastData.latitude;
        lastLongitude = Input.location.lastData.longitude;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Lat: " + lastLatitude + " " + "Long: " + lastLongitude;
    }
}
