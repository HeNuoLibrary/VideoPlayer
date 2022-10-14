using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlayerView : MonoBehaviour
{
    public VideoPlayerController controller;

    [Header("停止视频")] public Button button_Stop;
    [Header("视频 播放/暂停")] public Toggle toggle_PlayPause;
    [Header("时间 滑动条")] public Slider slider_Time;
    [Header("时间显示器")] public Text text_Time;
    [Space(20)]
    [Header("声音 开/关")] public Toggle toggle_Volume;
    [Header("声音 滑动条")] public Slider slider_Volume;

    private void Start()
    {
        controller.CurrentVolume = slider_Volume.value;
        button_Stop.onClick.AddListener(controller.videoPlayer.Stop);
        // 视频
        toggle_PlayPause.onValueChanged.AddListener((isOn) =>
        {
            if (isOn)
            {
                controller.videoPlayer.Pause();
            }
            else
            {
                controller.videoPlayer.Play();
            }
        });
        slider_Time.onValueChanged.AddListener((time) =>
        {
            if (EventSystemUtils.TriggerSelf(slider_Time))
            {
                controller.videoPlayer.time = time;
            }
        });

        // 声音
        toggle_Volume.onValueChanged.AddListener((isOn) =>
        {
            controller.audioSource.mute = !isOn;
            slider_Volume.value = isOn ? controller.CurrentVolume : 0;

        });
        slider_Volume.onValueChanged.AddListener((volume) =>
        {
            if (EventSystemUtils.TriggerSelf(slider_Volume))
            {
                controller.CurrentVolume = volume;
                controller.audioSource.volume = volume;
            }
        });
    }

    private void LateUpdate()
    {
        if (!EventSystemUtils.TriggerSelf(slider_Time))
        {
            if (slider_Time.maxValue != controller.SumTime) slider_Time.maxValue = controller.SumTime;
            slider_Time.value = controller.CurrentTime;
        }
        string ctime = TimeUtils.GetMinuteTime(controller.CurrentTime);
        text_Time.text = ctime + " / " + controller.SumTimeStr;
    }
}
