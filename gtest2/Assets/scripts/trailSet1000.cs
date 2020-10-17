using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trailSet1000 : MonoBehaviour
{
    Cbody[] CB;
    public GameObject cam;
    public GameObject space;


    private void Start()
    {
        space.GetComponent<Space>().delT = 0.005f;
        CB = FindObjectsOfType<Cbody>();
        foreach(Cbody body in CB)
        {
            body.GetComponent<TrailRenderer>().time = 1000f;
            //body.setMass();
            body.setRadius();
            
           
        }
        cam.GetComponent<camMOV>().rotation = true;

    }

    public void back()
    {
       
        SceneManager.LoadScene(0);
    }
    
}
