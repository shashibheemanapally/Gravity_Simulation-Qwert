using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//to destroy the spawned asteroid after 20 seconds..
public class asteroidDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
    }

    
}
