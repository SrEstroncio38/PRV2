using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryImage : MonoBehaviour
{

    public Vector3 realPos;
    public GameObject player;
    public Texture2D image;
    public float imageScale = 1;
    public float lingerTime = 1;
    public float distance = 3;
    private bool fadeIn = false;
    private bool fadeOut = false;

    public void Init()
    {
        MeshRenderer m = gameObject.GetComponent<MeshRenderer>();
        m.material = Resources.Load("SoundImage", typeof(Material)) as Material;

        m.material.color = new Color(1,1,1,0.0f);

        m.material.SetTexture("_MainTex",image);
        m.material.EnableKeyword("_DETAIL_MULX2");
        m.material.SetTexture("_DetailAlbedoMap", image);

        transform.position = realPos + new Vector3(0,3,0);
        gameObject.transform.localScale = new Vector3(0.5f * imageScale,0.5f * imageScale,0.5f * imageScale);
        fadeIn = true;
    }

    private void Update()
    {
        CalculateRotation();

        if (fadeIn)
        {
            transform.position -= new Vector3(0,Time.deltaTime * distance * 2,0);
            float alpha = (3 - (transform.position - realPos).y) / distance;
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, alpha);
            if ((transform.position - realPos).y < 0)
            {
                transform.position = realPos;
                fadeIn = false;
                Invoke("CallFadeOut",lingerTime);
            }
        }

        if (fadeOut)
        {
            transform.position -= new Vector3(0, Time.deltaTime * distance * 2, 0);
            float alpha = (3 - (realPos - transform.position).y) / distance;
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, alpha);
            if ((transform.position - realPos).y < -distance)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    private void CallFadeOut()
    {
        fadeOut = true;
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
