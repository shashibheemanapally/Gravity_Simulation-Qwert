using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class draws z component of velocity of each cbody..
public class lineZ : MonoBehaviour
{
    public Cbody body;
    public GameObject arrowZ;
    public GameObject parentBody;
    private GameObject arrow;
    LineRenderer lr;
    Rigidbody rb;
    MeshRenderer arrowMesh;
    public Material arrowZvelMet;

    private void Awake()
    {
        
        lr = GetComponent<LineRenderer>();
        rb = body.GetComponent<Rigidbody>();

        arrow = Instantiate(arrowZ, rb.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        arrow.transform.parent = parentBody.transform;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        arrowMesh = arrow.GetComponent<MeshRenderer>();
        arrowMesh.material = arrowZvelMet;


    }

    private void FixedUpdate()
    {
        //Debug.Log(CB.Length);


        
        
        float velz = body.currentVel.z;
        float radius ;
        bool arrowangle;
        if (velz <= 0)
        {
            radius = -1 * body.radius;
            arrowangle = false;
        }
        else
        {
            radius = body.radius;
            arrowangle = true;
        }
        Vector3 start = rb.position;
        Vector3 endz = start + new Vector3(0f, 0f,radius + velz);

        arrow.transform.position = endz;

        if (arrowangle == true)
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (arrowangle == false)
            arrow.transform.rotation = Quaternion.Euler(180f, 0f, 0f);

        lr.SetPosition(0, start);
        lr.SetPosition(1, endz);

    }
}