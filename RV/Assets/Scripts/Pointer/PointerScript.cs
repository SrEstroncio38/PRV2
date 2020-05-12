using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{

    public float maxRange = 50;

    private GameObject myLine;

    // Start is called before the first frame update
    void Start()
    {
        myLine = new GameObject();
        myLine.SetActive(false);
        myLine.AddComponent<LineRenderer>();
    }

    

    private void OnDestroy()
    {
        GameObject.Destroy(myLine);
    }

    // Update is called once per frame
    void Update()
    {

        myLine.SetActive(false);

        Vector3 endPos;

        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.TransformDirection(new Vector3(0, 0, 1)));

        endPos = ray.GetPoint(maxRange);

        if (Physics.Raycast(ray, out hit, maxRange))
        {

            PointableObject target = hit.collider.GetComponent<PointableObject>();
            if (target)
            {
                target.beingHit = true;
            }

            endPos = hit.point;
        }

        DrawLine(transform.position, endPos, Color.red);

    }



    private void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        myLine.transform.position = start;
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        myLine.SetActive(true);
    }
    
}