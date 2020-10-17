using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gamemanagerTes : MonoBehaviour
{
    public static GameObject selected;
    public static GameObject bodyselected;
    public static GameObject buttonselected;
    public static Rigidbody heavyBody;
    public static Material prevBodyMat;
    public static Color prevButMat;
    public static int bodycount = 0;
    
   

    Cbody cbody;

  // public Material buttonMaterial;
  // public Material sphereMaterial;


    public GameObject sphereButtonset;
    public GameObject spaceObj;
    public GameObject cam;
    public GameObject axes;
    public GameObject startCamlookAt;
    public GameObject zeroDistancePopup;
    
    

    GameObject bodyInstance;
    nullScriptforVtoggle[] lines ;

    private void Awake()
    {
        bodycount = 0;
       
       
    }
    public void addSphere()
    {
        bodyInstance = Instantiate(sphereButtonset) as GameObject;
    }
    public void deleteSelected()
    {
        if (selected != null && buttonselected.GetComponentInChildren<Text>().text!="Sphere 0")
        {
            Destroy(selected);
            Destroy(buttonselected);
            Destroy(bodyselected);
            bodycount--;
           // Debug.Log(bodycount);
        }
    }


    public void startSimulation()
    {
        bool zeroDistance = false;
        Cbody[] CB = FindObjectsOfType<Cbody>();
        lines = FindObjectsOfType<nullScriptforVtoggle>();
        int n = CB.Length;

       for(int i = 0; i < n; i++)
        {
            for(int j = i+1; j < n; j++)
            {
                if (CB[i].rb.position == CB[j].rb.position)
                    zeroDistance = true;
            }
        }


        if (zeroDistance == false) 
        {
            if (selected != null)
            {
                bodyselected.GetComponent<MeshRenderer>().material = prevBodyMat;
                buttonselected.GetComponent<Image>().color = prevButMat;
            }
            spaceObj.GetComponent<Space>().updateCB();
            spaceObj.GetComponent<Space>().enabled = true;
            getHeavyBody();
            cam.GetComponent<CinemachineFreeLook>().Follow = heavyBody.transform;
            cam.GetComponent<CinemachineFreeLook>().LookAt = heavyBody.transform;
            axes.SetActive(false);
            cam.GetComponent<camMOV>().rotation = true;
          


            foreach (var body in CB)
            {
                body.GetComponent<TrailRenderer>().time = 1000f;
                // body.GetComponent<SphereCollider>().enabled = true;

            }

        }

        else
        {
            spheresOverlapping();
        }

       


    }
    public void runModeback()
    {
        cam.GetComponent<CinemachineFreeLook>().Follow = startCamlookAt.transform;
        cam.GetComponent<CinemachineFreeLook>().LookAt = startCamlookAt.transform;
        cam.GetComponent<camMOV>().rotation = false;
        axes.SetActive(true);

        foreach (var line in lines)
        {
            line.gameObject.SetActive(true);
        }
        Cbody[] CB = FindObjectsOfType<Cbody>();
        foreach (var body in CB)
        {
            body.GetComponent<TrailRenderer>().time = 0f;
            body.rb.position = body.initialPos;
            //Debug.Log(body.rb.position);
            body.currentVel = body.initialVel;
           // Debug.Log(body.currentVel);
           // body.bodycoll.enabled = false;


        }


    }
    public void pauseSimulation()
    {
        spaceObj.GetComponent<Space>().enabled = !(spaceObj.GetComponent<Space>().enabled);

    }
    private void getHeavyBody()
    {
        Cbody[] CB = FindObjectsOfType<Cbody>();
         heavyBody = CB[0].rb;
        for (int i = 1; i < CB.Length; i++)
        {
            if (CB[i].rb.mass > heavyBody.mass)
                heavyBody = CB[i].rb;
        }
        
    }
    
    public void toggleAxes()
    {

        axes.SetActive(!(axes.activeInHierarchy));
    }
   
    public void toggleV()
    {
        
            foreach(var line in lines)
        {
            line.gameObject.SetActive(!(line.gameObject.activeInHierarchy));
        }
    }
    public void TogglebodyType()
    {
        Cbody[] CB = FindObjectsOfType<Cbody>();
        foreach(Cbody body in CB)
        {
            body.el = !(body.el);
        }
    }

    public void saveSim()
    {
        Cbody[] CB = FindObjectsOfType<Cbody>();
        CbodySpoof[] CBS = new CbodySpoof[CB.Length];
        int i = 0;
        foreach(Cbody body in CB)
        {
            Vector3Holder ip = new Vector3Holder(body.initialPos.x, body.initialPos.y, body.initialPos.z);
            Vector3Holder iv = new Vector3Holder(body.initialVel.x, body.initialVel.y, body.initialVel.z) ;

            CBS[i] = new CbodySpoof(body.rb.mass, body.radius, ip, iv);
            i++;
        }
        string simName = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        simName = simName.Replace("/", "_").Replace(" ","_").Replace(":","_");
        
        // savedSimulations.simulationList.Add(simName,CBS);
        // savedSimulations.simListSize++;


        CBSarrayHolder save = new CBSarrayHolder(simName, CBS);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/"+simName+".CBSarrayHolder");
       // Debug.Log("file created");
        bf.Serialize(file, save);
        file.Close();

        savedSimulations.simulationList.Add(simName);
        savedSimulations.simListSize++;


    }

    public void editorBackB()
    {
        SceneManager.LoadScene(0);
    }

    public void spheresOverlapping()
    {
        zeroDistancePopup.SetActive(true);
    }
}
