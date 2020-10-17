using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This class draws x component of velocity of each cbody..
public class lineX : MonoBehaviour
{
    public Cbody body;
    public GameObject parentBody;
    LineRenderer lr;
    public GameObject arrowX;
    private GameObject arrow;
    Rigidbody rb;
    MeshRenderer arrowMesh;
    public Material arrowXvelMet;
    private void Awake()
    {

        lr = GetComponent<LineRenderer>();
        rb = body.GetComponent<Rigidbody>();

        arrow =Instantiate(arrowX, rb.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        arrow.transform.parent = parentBody.transform;

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;


        arrowMesh = arrow.GetComponent<MeshRenderer>();
        arrowMesh.material = arrowXvelMet;
       
        
    }
   

    private void FixedUpdate()
    {
        //Debug.Log(CB.Length);


        
       
        float radius;
        float velx = body.currentVel.x;
        bool arrowangle;
        if (velx <= 0)
        {
             radius =-1* body.radius;
            arrowangle = false;

        }
        else
        {
            radius = body.radius;
            arrowangle = true;
        }
        
        Vector3 start = rb.position;
        Vector3 endx = start + new Vector3(radius + velx, 0f,0f);

        arrow.transform.position = endx;

        if (arrowangle == true)
            arrow.transform.rotation = Quaternion.Euler(0f, 90f, 90f);
        else if(arrowangle==false)
            arrow.transform.rotation = Quaternion.Euler(0f, -90f, -90f);

        lr.SetPosition(0, start);
        lr.SetPosition(1, endx);

    }
   
}