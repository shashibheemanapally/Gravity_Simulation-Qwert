using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class sphereButtonspawner : MonoBehaviour
{
    public GameObject listButton;
    public GameObject body;
    public GameObject list;

    public TMP_InputField radiusI;
    public TMP_InputField massI;
    public TMP_InputField posxI;
    public TMP_InputField posyI;
    public TMP_InputField poszI;
    public TMP_InputField velxI;
    public TMP_InputField velyI;
    public TMP_InputField velzI;
    

    public Material sphereMaterial;


    GameObject listItem;
    GameObject sphere;
    Cbody cbody;
    Color buttonMaterial = new Color(1f, 0.92f, 0f, 0.5f);



    private void Awake()
    {
        listItem = Instantiate(listButton) as GameObject;
        listItem.transform.SetParent(list.transform);
        listItem.transform.localPosition = Vector3.zero;
        listItem.GetComponentInChildren<Text>().text = ("Sphere " + gamemanagerTes.bodycount).ToString();
        listItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

        sphere = Instantiate(body) as GameObject;

       

        gamemanagerTes.bodycount++;



        listItem.GetComponent<Button>().onClick.AddListener(
             () =>
             {
                 if (gamemanagerTes.selected != null)
                 {


                     gamemanagerTes.bodyselected.GetComponent<MeshRenderer>().material = gamemanagerTes.prevBodyMat;
                     gamemanagerTes.buttonselected.GetComponent<Image>().color = gamemanagerTes.prevButMat;

                     gamemanagerTes.prevBodyMat = sphere.GetComponent<MeshRenderer>().material;
                     gamemanagerTes.prevButMat = listItem.GetComponent<Image>().color;

                 }

                 if (gamemanagerTes.selected == null)
                 {
                     gamemanagerTes.prevBodyMat = sphere.GetComponent<MeshRenderer>().material;
                     gamemanagerTes.prevButMat = listItem.GetComponent<Image>().color;
                 }





                 gamemanagerTes.selected = this.gameObject;
                 gamemanagerTes.bodyselected = sphere;
                 gamemanagerTes.buttonselected = listItem;
                

                 gamemanagerTes.bodyselected.GetComponent<MeshRenderer>().material = sphereMaterial;
                 gamemanagerTes.buttonselected.GetComponent<Image>().color = buttonMaterial;


                 showProperties();
               

               


             }
         );


    }
 
    public void showProperties()
    {
        cbody = gamemanagerTes.bodyselected.GetComponent<Cbody>();

        
       massI.text = (cbody.m).ToString();
       radiusI.text = (cbody.radius).ToString();
       posxI.text = (cbody.initialPos.x).ToString();
       posyI.text = (cbody.initialPos.y).ToString();
       poszI.text = (cbody.initialPos.z).ToString();
       velxI.text = (cbody.initialVel.x).ToString();
       velyI.text = (cbody.initialVel.y).ToString();
       velzI.text = (cbody.initialVel.z).ToString();

    }
    public void setProperties()
    {
        cbody = gamemanagerTes.bodyselected.GetComponent<Cbody>();

        cbody.radius = GetFloat(radiusI.text,0.0f);
        cbody.setRadius();

        cbody.m = GetFloat(massI.text, 0.0f); 
        cbody.setMass();
      
        cbody.initialPos = new Vector3(GetFloat(posxI.text, 0.0f) , GetFloat(posyI.text, 0.0f), GetFloat(poszI.text, 0.0f));
        cbody.setInitialPos();
      
        cbody.initialVel= new Vector3(GetFloat(velxI.text, 0.0f), GetFloat(velyI.text, 0.0f), GetFloat(velzI.text, 0.0f));
        cbody.setIntialVel();


    }
    private float GetFloat(string stringValue, float defaultValue)
    {
        float result = defaultValue;
        float.TryParse(stringValue, out result);
        return result;
    }
    

}
