using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//this class describes how bodies should move..
public class Cbody : MonoBehaviour
{
    public float m=1.0f;
    public float radius=0.5f;
    public float G;
   
    public Vector3 initialVel=new Vector3(0f,0f,0f);
    public Vector3 initialPos= new Vector3(0f, 0f, 0f);
    public Vector3 currentVel= new Vector3(0f, 0f, 0f);
    public Rigidbody rb;
   
    public bool el =false;
    Transform tr;
   // public TrailRenderer trail;
    MeshRenderer sphere;
    public Material[] trailMat = new Material[4];
    public Material[] bodyMat = new Material[4];

    
    

    bool collisionOccured = false;

    private void Awake()
    {
        int k = Random.Range(0, 4);

        this.GetComponent<TrailRenderer>().material = trailMat[k];
        this.GetComponent<TrailRenderer>().time = 0f;
        

        sphere = GetComponent<MeshRenderer>();
        sphere.material = bodyMat[k];


        currentVel = initialVel;
        tr = GetComponent<Transform>();

       // bodycoll = GetComponent<SphereCollider>();
        
      
        
    }
 
    public void updateVel(Cbody[] CB,float delT)
    {
        //vbc = currentVel;
        foreach (Cbody body in CB)
        {
            if ( body != this  )
            {
                Vector3 fdir = (body.rb.position - rb.position).normalized;
                Vector3 acc = (G * body.rb.mass * fdir) / ((body.rb.position - rb.position).sqrMagnitude);
               // Debug.Log(Vector3.Magnitude(rb.position - body.rb.position));
                currentVel += acc * delT;
                if(Vector3.Magnitude(body.rb.position - rb.position) <=(radius + body.radius))
                {
                    if (el == false)
                    {
                        Vector3 r = (body.rb.position - rb.position).normalized;
                        currentVel = currentVel - Vector3.Dot(currentVel, r) * r;
                    }
                    else if(el==true) 
                    {
                        if (body.collisionOccured == false)
                        {
                            float m1 = rb.mass;
                            float m2 = body.rb.mass;
                            Vector3 v1 = currentVel;
                            Vector3 v2 = body.currentVel;
                            Vector3 r = (body.rb.position - rb.position).normalized;
                            

                            currentVel = (v1 * (m1 - m2)) / (m1 + m2) + (2 * m2 * v2) / (m1 + m2);
                            body.currentVel = (2 * m1 * v1) / (m1 + m2) - ((m1 - m2) * v2) / (m1 + m2);

                            float normV1 = Vector3.Magnitude(Vector3.Dot(currentVel, r) * r);
                            float normV2 = Vector3.Magnitude(Vector3.Dot(body.currentVel, r) * r);
                            if (normV1<=0.1f || normV2<=0.1f)
                            {
                                currentVel = currentVel - Vector3.Dot(currentVel, r) * r;
                                body.currentVel = body.currentVel + Vector3.Dot(body.currentVel, r) * r;
                               // Debug.Log(currentVel + " " + body.currentVel);

                            }
                           
                            collisionOccured = true;

                        }
                        else if (collisionOccured == true)
                        {
                            collisionOccured = false;

                        }

                    }
                }
            }

        }
    }
    public void updatePos(float delT)
    {
        rb.position += currentVel * delT;
       
    }


    public void setRadius()
    {
        tr.localScale = new Vector3(2 * radius, 2 * radius, 2 * radius);
    }

    public void setMass()
    {
        rb.mass = m;
    }
    public void setInitialPos()
    {
        rb.position = initialPos;
    }
    public void setIntialVel()
    {
        currentVel = initialVel;
    }

   
  

  

}
