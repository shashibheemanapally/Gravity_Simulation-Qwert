using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


//this class serielizes the object having the name "selected" and serielized object contains 
//cbodyspoof array and is used to spawn Cbodies
public class GameManage2 : MonoBehaviour
{
    

    public GameObject linedSp;
    public GameObject space;
    public GameObject axes;
    public GameObject cam;
    public Material transMatTrail;
    
    

    CbodySpoof[] spoofbodylist ;
    GameObject bodyInstance;
    Cbody bodyInstanceCbody;
    nullScriptforVtoggle[] lines;
    Cbody[] CB;
    Rigidbody heavyBody;
    





    private void Awake()
    {

       

        

        if (File.Exists(Application.persistentDataPath + "/" + savedSimulations.selectedB + ".CBSarrayHolder"))
        {
           

          
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + savedSimulations.selectedB + ".CBSarrayHolder", FileMode.Open);
            CBSarrayHolder save = (CBSarrayHolder)bf.Deserialize(file);
            file.Close();

            CbodySpoof[] CBS = save.CBS;

            foreach (var spoofBody in CBS)
            {
                bodyInstance = Instantiate(linedSp) as GameObject;
                bodyInstanceCbody = bodyInstance.GetComponent<Cbody>();
                

                bodyInstanceCbody.m = spoofBody.mass;
                bodyInstanceCbody.setMass();

                bodyInstanceCbody.radius = spoofBody.radius;
                bodyInstanceCbody.setRadius();

                bodyInstanceCbody.initialPos = new Vector3(spoofBody.initialPos.x, spoofBody.initialPos.y, spoofBody.initialPos.z); 
                bodyInstanceCbody.setInitialPos();

                bodyInstanceCbody.initialVel = new Vector3(spoofBody.initialVel.x, spoofBody.initialVel.y, spoofBody.initialVel.z);
                bodyInstanceCbody.setIntialVel();
            }
        }
        lines = FindObjectsOfType<nullScriptforVtoggle>();

        CB = FindObjectsOfType<Cbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {           
                foreach (Cbody body in CB)
                {
                    body.GetComponent<TrailRenderer>().material = transMatTrail;
                }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {        
                foreach (Cbody body in CB)
                {
                    body.setTrail(Random.Range(0, 4));
                }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            vLinesToggle();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            cam.GetComponent<camMOV>().rotation = !(cam.GetComponent<camMOV>().rotation);
        }

    }
    private void Start()
    {
        heavyBody = CB[0].rb;
        foreach (Cbody body in CB)
        {
            body.GetComponent<TrailRenderer>().time = 0f;
           // body.GetComponent<SphereCollider>().enabled = true;

            if (body.rb.mass > heavyBody.mass)
                heavyBody = body.rb;
        }
        cam.GetComponent<camMOV>().rotation = true;
        cam.GetComponent<CinemachineFreeLook>().Follow = heavyBody.transform;
        cam.GetComponent<CinemachineFreeLook>().LookAt = heavyBody.transform;
    }

    public void pause()
    {
        foreach (Cbody body in CB)
        {
            body.GetComponent<TrailRenderer>().time = 1000f;
            

        }
        space.GetComponent<Space>().enabled = !(space.GetComponent<Space>().enabled);
        
    }

    public void vLinesToggle()
    {
        foreach (var line in lines)
        {
            line.gameObject.SetActive(!(line.gameObject.activeInHierarchy));
        }
    }
    public void toggleAxes()
    {
        axes.SetActive(!(axes.activeInHierarchy));
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

}
