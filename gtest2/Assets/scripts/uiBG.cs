using System.Collections;
using System.Collections.Generic;

using UnityEngine;


//this class spawns given gameobject and adds force and torque..
public class uiBG : MonoBehaviour
{
    public GameObject p;
    Vector3 pos = new Vector3(0f, 0f, 0f);
    Quaternion rot = new Quaternion(1f, 1f, 1f, 1f);
    GameObject goInstance;
    Rigidbody rb;
    Vector3 r = new Vector3(-100f, 100f, 150f);
    
    public void make() 
    {
        
        goInstance=Instantiate(p,pos,rot) as GameObject;
    }
    private void FixedUpdate()
    {
        if (goInstance != null) 
        {
            rb = goInstance.GetComponent<Rigidbody>();
            rb.AddTorque(rb.position - r);
            rb.AddForce(0f, 0f, 50f);
        }
        
    }

}
