using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cinema : PointableObject
{

    public VideoPlayer screen;
    public AudioSource leftSpeaker;
    public AudioSource rightSpeaker;

    public float delayBetweenVideos = 2.0f;

    public List<CinemaMovie> movieList;

    private int movieIdx;

    [Serializable]
    public class CinemaMovie {
        public VideoClip video;
        public AudioClip leftAudio;
        public AudioClip rightAudio;
    }



    public override void Start()
    {
        base.Start();
        movieIdx = UnityEngine.Random.Range(0, movieList.Count);
        if (movieIdx >= movieList.Count)
            movieIdx -= movieList.Count;

        screen.loopPointReached += VideoOver;

        //SetMovie(movieIdx);
    }

    private void VideoOver(VideoPlayer vp)
    {
        PerformAction();
    }

    public override void PerformAction()
    {

        movieIdx++;
        while (movieIdx > movieList.Count - 1)
            movieIdx -= movieList.Count;
        SetMovie(movieIdx);

    }

    private void SetMovie(int idx)
    {

        CinemaMovie currentMovie = movieList[idx];

        screen.Stop();
        leftSpeaker.Stop();
        rightSpeaker.Stop();

        screen.clip = currentMovie.video;
        leftSpeaker.clip = currentMovie.leftAudio;
        rightSpeaker.clip = currentMovie.rightAudio;

        screen.time = 0;
        leftSpeaker.time = 0;
        rightSpeaker.time = 0;

        screen.Stop();
        leftSpeaker.Stop();
        rightSpeaker.Stop();

        leftSpeaker.volume = 1;
        rightSpeaker.volume = 1;

        Invoke("StartVideos", delayBetweenVideos);

    }

    private void StartVideos()
    {
        screen.Play();
        leftSpeaker.Play();
        rightSpeaker.Play();
    }

    public void StopVideos()
    {
        screen.Stop();
        leftSpeaker.Stop();
        rightSpeaker.Stop();
    }

}
