using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamNov : MonoBehaviour
{
    Vector3 camSpeed = new Vector3(0f, 0f, 1f);
    Vector3 camRot = new Vector3(0f,0f,5f);
    Vector3 asteroidPos;
    GameObject asteroidSpawned;
    Rigidbody rb;
    Vector3 finalPoint = new Vector3(0f, 0f, 10000f);
    Vector3 rot = new Vector3(-100f, 100f, -100);
    bool APswitch = true;

    public Camera cam;
    public Material[] skybM = new Material[3];
    public GameObject[] asteroids = new GameObject[8];


    private void Awake()
    {
        cam.transform.position = new Vector3(0f, 0f, -10f);

        

    }
    void Start()
    {
        int k = Random.Range(0, 3);
        RenderSettings.skybox = skybM[k];
        

        InvokeRepeating("makeAsteroid", 2f,Random.Range(0.3f,0.8f));

        //Debug.Log(cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f)));
    }

   
    void Update()
    {
        cam.transform.position -= camSpeed * Time.deltaTime;
        cam.transform.eulerAngles += camRot*Time.deltaTime;
        
    }

    void makeAsteroid()
    {
        //float k = 1.1f-Vector3.Magnitude(Random.insideUnitCircle);
        int a = Random.Range(0, 8);
        //float size = k * 20f;
        int size = Random.Range(1, 31);

        asteroidPos = AP(size);

        asteroidSpawned = Instantiate(asteroids[a], asteroidPos, new Quaternion()) as GameObject;

        
        asteroidSpawned.transform.localScale = new Vector3(size, size, size);
        rb = asteroidSpawned.GetComponent<Rigidbody>();
       
        rb.AddTorque(rb.position-rot);
        rb.AddForce(Random.Range(-100f,100f),Random.Range(-100f,100f),20000f/size);
       

    }

    //gives position of to be spawned asteroid
    Vector3 AP(int size)
    {
        if (APswitch == true)
        {
            APswitch = false;
            return new Vector3(Random.Range(size / 2, 20f), Random.Range(-20f, 20f), cam.transform.position.z - 5f);

            
        }
        else
        {
            APswitch = true;
            return new Vector3(Random.Range( -20f,-1*size / 2), Random.Range(-20f, 20f), cam.transform.position.z - 5f);
            
        }
    }
}
