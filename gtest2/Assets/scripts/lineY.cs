using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class draws y component of velocity of each cbody..
public class lineY : MonoBehaviour
{
    public Cbody body ;
    public GameObject arrowY;
    public GameObject parentBody;
    private GameObject arrow;
    LineRenderer lr;
    Rigidbody rb;
    MeshRenderer arrowMesh;
    public Material arrowYvelMet;

    private void Awake()
    {
        
        lr = GetComponent<LineRenderer>();
        rb = body.GetComponent<Rigidbody>();

        arrow = Instantiate(arrowY, rb.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        arrow.transform.parent = parentBody.transform;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        arrowMesh = arrow.GetComponent<MeshRenderer>();
        arrowMesh.material = arrowYvelMet;


    }

    private void FixedUpdate()
    {
        //Debug.Log(CB.Length);
       
        
            
            
            float vely = body.currentVel.y;
            float radius ;
             bool arrowangle;
             if (vely <= 0)
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
            Vector3 endy = start + new Vector3(0f, radius + vely, 0f);

            arrow.transform.position = endy;

            if (arrowangle == true)
                 arrow.transform.rotation = Quaternion.Euler(-90f, 0f,- 90f);
            else if (arrowangle == false)
                  arrow.transform.rotation = Quaternion.Euler(90f, 0f, 90f);

             lr.SetPosition(0, start);
            lr.SetPosition(1, endy);
        
    }
}
