using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProducer : PointableObject
{

    public GameObject player;
    public AudioSource speaker;
    public AudioClip clip;
    public Texture2D image;
    public float imageScale = 1;
    [Range(0.0f, 1.0f)]
    public float volume = 1;

    new void Start()
    {
        if (!speaker)
            speaker = gameObject.GetComponent<AudioSource>();
    }

    public override void PerformAction()
    {
        speaker.Stop();
        speaker.clip = clip;
        speaker.time = 0;
        speaker.volume = volume;
        speaker.mute = false;
        speaker.Play();

        if (image)
            SpawnImage();
    }

    private void SpawnImage()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position - transform.position;
        endPos.y = 0;
        endPos.Normalize();
        Vector3 imagePos = startPos + endPos * 3;

        TemporaryImage imageObject = GameObject.CreatePrimitive(PrimitiveType.Plane).AddComponent<TemporaryImage>();
        imageObject.realPos = imagePos;
        imageObject.player = player;
        imageObject.image = image;
        imageObject.imageScale = imageScale;
        imageObject.Init();
    }
}
