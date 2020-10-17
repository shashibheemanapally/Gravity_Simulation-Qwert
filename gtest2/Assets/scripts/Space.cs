using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This class introduces time gap between each concecutive physical movement of all cbodies
public class Space : MonoBehaviour
{
    
    public float delT=0.02f;
    Cbody[] CB;

    Vector3 CG = new Vector3();

    
  
    private void Start()
    {
        CB = FindObjectsOfType<Cbody>();

        

      //  foreach (var body in CB)
      //  {
      //      body.GetComponent<TrailRenderer>().time = 1000f;
      //      body.GetComponent<SphereCollider>().enabled = true;
      //     
      //  }
    }
    private void FixedUpdate()
    {

        CG = new Vector3(0f, 0f, 0f);


        foreach (var body in CB)
        {
            if (body.rb != null)
            {
                body.updateVel(CB, delT);

            }
            
        }
        foreach (var body in CB)
        {
            if (body.rb != null)
            {
            
                body.updatePos(delT); 

            }

           // CG  +=body.rb.position;
            
        }

       // updateCGpos();
        
    }
    public void runModeBack()
    {   
        this.GetComponent<Space>().enabled = false;
      // foreach (var body in CB)
      // {
      //     body.GetComponent<TrailRenderer>().time = 0f;
      //     body.rb.position = body.initialPos;
      //     body.currentVel = body.initialVel;
      //     body.bodycoll.enabled = false;
      //
      //
      // }
    }
    public void updateCB()
    {
        CB = FindObjectsOfType<Cbody>();
    }
    private void updateCGpos() 
    {
        Debug.Log(CG);

    }

}
