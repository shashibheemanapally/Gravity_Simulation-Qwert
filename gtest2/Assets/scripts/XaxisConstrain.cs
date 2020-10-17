using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Cinemachine;
//using UnityEditor.UIElements;


    //This class spawns coordinate System and arrow objects associated with each axis..
public class XaxisConstrain : MonoBehaviour
{
    // Camera cam;
    // Vector3 viewportXmax ;
    // Vector3 worldPoint;
    // float screenTocentreMAg;
    LineRenderer lrx;
    LineRenderer lry;
    LineRenderer lrz;
    MeshRenderer meshx;
    MeshRenderer meshy;
    MeshRenderer meshz;
   //public CinemachineFreeLook cm;

    public GameObject yg;
    public GameObject zg;
    public GameObject parentBody;
    public Material[] mat = new Material[4];

    public GameObject arrow;
    private GameObject arrowx;
    private GameObject arrowy;
    private GameObject arrowz;


  
    public void Start()
    {  
        
       // float cmDiam= 2*cm.m_Orbits[1].m_Radius;
        

        lrx = GetComponent<LineRenderer>();
        lrx.SetPosition(0, new Vector3(0f, 0f, 0f));
        lrx.SetPosition(1, new Vector3(12f, 0f, 0f));

     

        lry = yg.GetComponent<LineRenderer>();
        lrz=zg.GetComponent<LineRenderer>();

        lry.SetPosition(0, new Vector3(0f, 0f, 0f));
        lry.SetPosition(1, new Vector3( 0f,8f, 0f));

        lrz.SetPosition(0, new Vector3(0f, 0f, 0f));
        lrz.SetPosition(1, new Vector3( 0f, 0f,8f));

        arrowx = Instantiate(arrow, lrx.GetPosition(1), Quaternion.Euler(0f, 90f,90f)) as GameObject;
        arrowx.transform.parent = parentBody.transform;
        arrowy = Instantiate(arrow, lry.GetPosition(1), Quaternion.Euler(-90f, 0f, -90f)) as GameObject;
        arrowy.transform.parent = parentBody.transform;
        arrowz = Instantiate(arrow, lrz.GetPosition(1), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        arrowz.transform.parent = parentBody.transform;

        meshx = arrowx.GetComponent<MeshRenderer>();
        meshy = arrowy.GetComponent<MeshRenderer>();
        meshz = arrowz.GetComponent<MeshRenderer>();

        meshx.material = mat[0];
        meshy.material = mat[1];
        meshz.material = mat[2];

        lrx.material = mat[3];
        lry.material = mat[3]; 
        lrz.material = mat[3];


    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            
            increasePoints();
            
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //scroll up
           decreasePoints(); 
      
        }
    }

   // void decreasePoints()
   // {
   //     float cmDiam = 2 * cm.m_Orbits[1].m_Radius;
   //     lr.SetPosition(1,new Vector3(cmDiam / 3f, 0f,0f));
   //   
   // }

    void increasePoints()
    {
        // lr.SetPosition(1, new Vector3(lr.GetPosition(1).x + 1f, 0f, 0f));
        //  float cmDiam = 2 * cm.m_Orbits[1].m_Radius;
        //  lrx.SetPosition(1, new Vector3(cmDiam / 3.5f, 0f, 0f));
        //  lry.SetPosition(1, new Vector3( 0f, cmDiam / 5.5f, 0f));
        //  lrz.SetPosition(1, new Vector3(0f, 0f,cmDiam / 5f));

        lrx.SetPosition(1, new Vector3(lrx.GetPosition(1).x*1.08f, 0f, 0f));
        lry.SetPosition(1, new Vector3( 0f, lry.GetPosition(1).y * 1.08f, 0f));
        lrz.SetPosition(1, new Vector3(0f, 0f, lrz.GetPosition(1).z * 1.08f));

        arrowx.transform.position = lrx.GetPosition(1);
        arrowy.transform.position = lry.GetPosition(1);
        arrowz.transform.position = lrz.GetPosition(1);

    }
    void decreasePoints()
    {
        // lr.SetPosition(1, new Vector3(lr.GetPosition(1).x + 1f, 0f, 0f));
        //  float cmDiam = 2 * cm.m_Orbits[1].m_Radius;
        //  lrx.SetPosition(1, new Vector3(cmDiam / 3.5f, 0f, 0f));
        //  lry.SetPosition(1, new Vector3( 0f, cmDiam / 5.5f, 0f));
        //  lrz.SetPosition(1, new Vector3(0f, 0f,cmDiam / 5f));

        lrx.SetPosition(1, new Vector3(lrx.GetPosition(1).x / 1.08f, 0f, 0f));
        lry.SetPosition(1, new Vector3(0f, lry.GetPosition(1).y / 1.08f, 0f));
        lrz.SetPosition(1, new Vector3(0f, 0f, lrz.GetPosition(1).z / 1.08f));

        arrowx.transform.position = lrx.GetPosition(1);
        arrowy.transform.position = lry.GetPosition(1);
        arrowz.transform.position = lrz.GetPosition(1);

    }
    


}
