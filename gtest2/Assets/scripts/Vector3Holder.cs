using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//replacement of Vector3 as Vector3 cannot be serielized..
[System.Serializable]
public class Vector3Holder 
{
    public float x;
    public float y;
    public float z;

    public Vector3Holder()
    {
        x = 0f;
        y = 0f;
        z = 0f;

    }
    public Vector3Holder(float x,float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
