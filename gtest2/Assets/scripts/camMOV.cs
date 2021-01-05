using Cinemachine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;


//this class describes the movement of camera and operates zoom in and zoom out..
public class camMOV : MonoBehaviour
{
   // public Transform tr;
    public GameObject startCamPoint;
    CinemachineFreeLook cm;
    public bool rotation ;
    //public bool camMov = true;

    private void Awake()
    {
          cm = GetComponent<CinemachineFreeLook>();
          rotation = false;
        //  if (tr == null)
        //  {
        //      cm.Follow = startCamPoint.transform;
        //      cm.LookAt = startCamPoint.transform;
        //  }
        //      
        //  else
        //  {
        //      cm.Follow = tr;
        //      cm.LookAt = tr;
        //  }

        cm.Follow = startCamPoint.transform;
        cm.LookAt = startCamPoint.transform;


        cm.transform.SetPositionAndRotation(new Vector3(),new Quaternion());
        
        cm.m_Orbits[0].m_Height = 30f;
        cm.m_Orbits[0].m_Radius = 0f;

        cm.m_Orbits[1].m_Height = 0f;
        cm.m_Orbits[1].m_Radius = 30f;

        cm.m_Orbits[2].m_Height = -30f;
        cm.m_Orbits[2].m_Radius = 0f;
    }
    private void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            cm.m_YAxis.m_MaxSpeed = 2f;
            cm.m_XAxis.m_MaxSpeed = 300f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cm.m_YAxis.m_MaxSpeed = 0f;
            cm.m_XAxis.m_MaxSpeed = 0f;
        }
        if(Input.GetMouseButton(0)!=true && rotation==true)
        {   
            cm.m_XAxis.Value-=  0.05f;
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0f )
        {
            //scroll down
            float amp = Vector3.Magnitude(cm.transform.position - cm.m_LookAt.position);
            cm.m_Orbits[0].m_Height += amp*0.1f;
            cm.m_Orbits[1].m_Radius += amp * 0.1f;
            cm.m_Orbits[2].m_Height += -1*amp * 0.1f;

        }
    

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //scroll up
            float amp = Vector3.Magnitude(cm.transform.position - cm.m_LookAt.position);
            cm.m_Orbits[0].m_Height -= amp * 0.1f;
            cm.m_Orbits[1].m_Radius -= amp * 0.1f;
            cm.m_Orbits[2].m_Height -= -1 * amp * 0.1f;
        }
    }

    public void rotationToggle()
    {
        rotation = !(rotation);
    }

}
