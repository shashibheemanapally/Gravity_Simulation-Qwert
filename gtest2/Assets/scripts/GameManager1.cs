using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager1 : MonoBehaviour
{
    private GameObject bodyInstance;
    
    GameObject bodySelected;
    List<SphereButtonGroup> bodyList;
    static int bodycount = 1;
    

    public GameObject body;
    public GameObject list;
    public GameObject listButton;

    static SphereButtonGroup selected;


    private void Awake()
    {
       bodyList = new List<SphereButtonGroup>();
    }

    public void addBody()
    {
        bodyInstance= Instantiate(body) as GameObject;
       
        var listItem = Instantiate(listButton) as GameObject;
        listItem.transform.SetParent(list.transform) ;
        listItem.transform.localPosition = Vector3.zero;
        listItem.GetComponentInChildren<Text>().text = ("sphere"+bodycount).ToString();

        listItem.GetComponent<Button>().onClick.AddListener(
                    () =>
                    {
                        Debug.Log(bodycount);
                        Debug.Log(bodyList.Count);
                        
                    }
        );

        bodyList.Add(new SphereButtonGroup(bodyInstance, listItem));
      
        bodycount++;
    }
}
