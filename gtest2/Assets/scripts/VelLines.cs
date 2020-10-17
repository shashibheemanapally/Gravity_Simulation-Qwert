using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VelLines : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lr;
    Cbody body;
    SphereCollider bodycoll;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        body = GetComponent<Cbody>();
        bodycoll = GetComponent<SphereCollider>();

    }
    private void FixedUpdate()
    {
        float velx = body.currentVel.x;
        float vely = body.currentVel.y;
        float velz = body.currentVel.z;

        float radius = bodycoll.radius;
        
        Vector3 start = rb.position;
        Vector3 endx = start + new Vector3(radius + velx, 0f, 0f);
        Vector3 endy = start + new Vector3(0f, radius + vely, 0f);
        Vector3 endz = start + new Vector3(0f, 0f, radius + velz);

       lr.SetPosition(0, start);
       lr.SetPosition(1,endy);

     //   lr.SetPosition(0, start);
     //   lr.SetPosition(1, endz);
     //
     //   lr.SetPosition(0, start);
     //   lr.SetPosition(1, endx);


    }
}
