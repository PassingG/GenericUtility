using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Notifications.Android;
using UnityEngine;

public class NotificationManager : BaseMonoSingleton<NotificationManager>
{
    [Serializable]
    private struct NotificationData
    {
        [Header("Info")]
        public string id;
        public string des;

        [Header("Time"), Space(10)]
        [Range(-1,12)]
        public int month;

        [Range(-1,31)]
        public int day;

        [Range(-1,24)]
        public int hour;

        [Range(-1,60)]
        public int minute;
        
        [Header("TimeSpan"), Space(10)]
        [Range(0,365)]
        public int repeat_day;

        [Range(0,24)]
        public int repeat_hours;

        [Range(0,60)]
        public int repeat_minute;

        [Header("Style"), Space(10)]
        public NotificationStyle style;
    }

    public readonly string defaultChannelName = "Default";

    [SerializeField]
    private NotificationData[] notificationDatas;

    public void Initialize_Notification(bool bOnOff)
    {
#if UNITY_ANDROID
        AndroidNotificationCenter.Initialize();

        //예약 알림 삭제 
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        //기존 알림 삭제
        AndroidNotificationCenter.CancelAllNotifications();
        //채널 삭제
        AndroidNotificationCenter.DeleteNotificationChannel(defaultChannelName);

        // 알림
        if (bOnOff)
        {
            // 알림 채널을 생성
            Debug.Log($"[{GetType()}/{MethodBase.GetCurrentMethod().Name}] Create channel({defaultChannelName})");

            AndroidNotificationCenter.RegisterNotificationChannel(new AndroidNotificationChannel()
            {
                Id = defaultChannelName,
                Name = defaultChannelName,
                Description = $"{defaultChannelName} notifications",
                CanBypassDnd = true,
                Importance = Importance.Default,
                CanShowBadge = true,
                EnableLights = true,
                EnableVibration = true
            });

            try
            {
                DateTime fireTime = DateTime.Now;

                for (int i = 0; i < notificationDatas.Length; i++)
                {
                    NotificationData dateData = notificationDatas[i];

                    int monthTmp = dateData.month == -1 ? fireTime.Month : dateData.month;
                    int dayTmp = dateData.day == -1 ? fireTime.Day : dateData.day;
                    int hourTmp = dateData.hour == -1 ? fireTime.Hour : dateData.hour;
                    int minuteTmp = dateData.minute == -1 ? fireTime.Minute : dateData.minute;

                    DateTime defaultNotificationFireTime = new DateTime(fireTime.Year, monthTmp, dayTmp, hourTmp, minuteTmp, 0);
                    TimeSpan span = new TimeSpan(dateData.repeat_day, dateData.repeat_hours, dateData.repeat_minute, 0);

                    while(defaultNotificationFireTime < fireTime)
                    {
                        defaultNotificationFireTime = defaultNotificationFireTime.Add(span);
                    }

                    var notification = new AndroidNotification();
                    notification.Title = Helper.LocalizeTxt.GetNotification(dateData.id, Helper.LocalizeTxt.ENotification.Title);
                    notification.Text = Helper.LocalizeTxt.GetNotification(dateData.id, Helper.LocalizeTxt.ENotification.Text);
                    notification.FireTime = defaultNotificationFireTime; // 알림 시간
                    notification.RepeatInterval = span; // 반복 주기
                    notification.Style = dateData.style;

                    AndroidNotificationCenter.SendNotification(notification, defaultChannelName);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return;
            }
            return;
        }

#endif
    }

}
