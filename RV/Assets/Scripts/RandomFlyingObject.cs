using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyingObject : MonoBehaviour
{

    public BoxCollider zone;
    public GameObject player;

    public float speed = 1.5f;
    [Range(0.0f, 1.0f)]
    public float volume = 1;
    public float minWaitTime = 5.0f;
    public float maxWaitTime = 20.0f;

    private AudioSource audioSource;
    private float waitTime;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        NewPosition();
        TpThere();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, newPosition) < 1)
            NewPosition();
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
        CalculateRotation();

        waitTime -= Time.deltaTime;
        if (waitTime < 0)
        {
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            audioSource.Stop();
            audioSource.time = 0;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }

    private void NewPosition()
    {
        newPosition = zone.transform.position;
        newPosition += new Vector3(Random.Range(-zone.transform.localScale.x / 2.0f, zone.transform.localScale.x / 2.0f), Random.Range(-zone.transform.localScale.y / 2.0f, zone.transform.localScale.y / 2.0f), Random.Range(-zone.transform.localScale.z / 2.0f, zone.transform.localScale.z / 2.0f));
    }

    private void TpThere()
    {
        transform.position = newPosition;
    }

    private void CalculateRotation()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 dirOld = dir;
        dir.y = 0;
        float angley = Vector3.Angle(dir, new Vector3(0, 0, 1));
        if (Vector3.Cross(dir, new Vector3(0, 0, 1)).y > 0)
            angley *= -1;
        float anglex = Vector3.Angle(dir, dirOld);
        if (dirOld.y > 0)
            anglex *= -1;
        transform.rotation = Quaternion.Euler(90 + anglex, angley, 0);
    }

}
