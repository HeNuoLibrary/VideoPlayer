// -----------------------------------------------
// Copyright © Sirius. All rights reserved.
// CreateTime: 2021/12/27   17:8:43
// -----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HeNuo.Video
{
    public static class EventSystemUtils
    {
        public static bool TriggerSelf(this Selectable self)
        {
            if (self is Dropdown)
            {
                Dropdown dropdown = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Dropdown>();
                if (dropdown == self) return true;
            }
            else if (EventSystem.current.currentSelectedGameObject == self.gameObject)
            {
                return true;
            }
            return false;
        }
    }

    public static class TimeUtils
    {
        /// <summary>
        /// 获取时间格式字符串，显示mm:ss
        /// </summary>
        /// <returns>The minute time.</returns>
        /// <param name="time">Time.</param>
        public static string GetMinuteTime(float time)
        {
            int mm, ss;
            string stime = "0:00";
            if (time <= 0) return stime;
            mm = (int)time / 60;
            ss = (int)time % 60;
            if (mm > 60)
                stime = "59:59";
            else if (mm < 10 && ss >= 10)
            {
                stime = "0" + mm + ":" + ss;
            }
            else if (mm < 10 && ss < 10)
            {
                stime = "0" + mm + ":0" + ss;
            }
            else if (mm >= 10 && ss < 10)
            {
                stime = mm + ":0" + ss;
            }
            else
            {
                stime = mm + ":" + ss;
            }
            return stime;
        }
    }
}