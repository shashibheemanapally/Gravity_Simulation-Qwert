using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class is spoof of Cbody class to store cbody values to serialize the object of this class.

[System.Serializable]
public class CbodySpoof 
{
    public float mass = 1f;
    public float radius = 0.5f;
    //public Vector3 initialPos = new Vector3();
    //public Vector3 initialVel = new Vector3();
    public Vector3Holder initialPos = new Vector3Holder();
    public Vector3Holder initialVel = new Vector3Holder();
    public CbodySpoof(float mass,float radius,Vector3Holder iP,Vector3Holder iV)
    {
        this.mass = mass;
        this.radius = radius;
        this.initialPos = iP;
        this.initialVel = iV;
    }
}
