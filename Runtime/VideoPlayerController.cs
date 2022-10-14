using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
namespace HeNuo.Video
{
    public class VideoPlayerController : MonoBehaviour
    {
        public string SumTimeStr { get; set; } = "00:00";
        public float SumTime { get; set; }
        public float CurrentTime { get; set; }
        public float CurrentVolume { get; set; }

        public VideoPlayer videoPlayer;
        public AudioSource audioSource;


        private void Start()
        {
            videoPlayer.prepareCompleted += PrepareCompleted;
        }

        private void Update()
        {
            if (videoPlayer.isPlaying) CurrentTime = (float)videoPlayer.time;
        }

        private void PrepareCompleted(VideoPlayer source)
        {
            float frameCount = source.frameCount;
            float frameRate = source.frameRate;

            SumTime = frameCount / frameRate;
            SumTimeStr = TimeUtils.GetMinuteTime(SumTime);
            CurrentTime = 0;
        }
    }
}