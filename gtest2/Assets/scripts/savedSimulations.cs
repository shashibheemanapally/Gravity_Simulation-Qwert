using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//this class adds the buttons of saved simulation by deserielizing the hashset and adds action listener to each button
public  class savedSimulations : MonoBehaviour
{
   
    public static int simListSize=0;
    //public static Dictionary<string, CbodySpoof[]> simulationList = new Dictionary<string, CbodySpoof[]>();
    public static HashSet<string> simulationList = new HashSet<string>();
    public static string selectedB;

    public GameObject listB;
    public GameObject list;

    GameObject listItem;

    private void Awake()
    {
       // Debug.Log("list size" + simListSize);
        // foreach (KeyValuePair<string, CbodySpoof[]> pair in simulationList)

        if (File.Exists(Application.persistentDataPath + "/simulationList.List"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/simulationList.List", FileMode.Open);
            HashSet<string> save = (HashSet<string>)bf.Deserialize(file);
            file.Close();

            foreach(string str in save)
            {
                simulationList.Add(str);
            }

        }


            foreach (var str in simulationList)
        {
            listItem = Instantiate(listB) as GameObject;
            listItem.transform.SetParent(list.transform);
            listItem.transform.localPosition = Vector3.zero;
            listItem.GetComponentInChildren<Text>().text = str;
            listItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

            listItem.GetComponent<Button>().onClick.AddListener(
                () =>
                {
                    selectedB = str;
                    SceneManager.LoadScene(2);
                 


                }
            );


        }
    }



}
