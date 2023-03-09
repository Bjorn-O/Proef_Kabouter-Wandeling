using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine.Assertions;
using UnityEngine;

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
    private int notificationsToSend;

    private void Awake()
    {
        notificationsToSend = 2;
        AndroidNotificationCenter.RegisterNotificationChannel(c);
        notification.Title = "Message from Joe Biden!";
        notification.Text = "It's joever";
        notification.SmallIcon = "obama";
        notification.LargeIcon = "joever";
        notification.FireTime = System.DateTime.Now.AddSeconds(2);
    }


    private void Update()
    {
        AndroidNotificationCenter.SendNotification(notification, "Notification_Channel");
    }
}
