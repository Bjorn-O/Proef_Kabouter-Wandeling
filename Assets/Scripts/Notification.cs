using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class NotificationEvent : UnityEvent<string, string, int>
{
}

public class Notification : MonoBehaviour
{

    AndroidNotificationChannel c = new AndroidNotificationChannel()
    {
        Id = "Notification_Channel",
        Name = "Default Channel",
        Importance = Importance.High,
        Description = "Generic notifications",
    };

    AndroidNotification notification = new AndroidNotification();

    private void Awake()
    {
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }

    /// <summary>
    /// Function used to send notifications
    /// </summary>
    /// <param name="notifTitle">Title of the notification.</param>
    /// <param name="notifText">Text of the notification.</param>
    /// <param name="fireTime">Amount of time to delay the notification with in seconds.</param>
    public void SendNotification(string notifTitle, string notifText, int fireTime)
    {
        notification.Title = notifTitle;
        notification.Text = notifText;
        notification.FireTime = System.DateTime.Now.AddSeconds(fireTime);
        AndroidNotificationCenter.SendNotification(notification, "Notification_Channel");
    }
}
