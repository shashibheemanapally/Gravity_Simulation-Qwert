using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager0 : MonoBehaviour
{
    public void loadEditor()
    {
        SceneManager.LoadScene(1);
    }


    public void twoBody()
    {
        SceneManager.LoadScene(3);
    }
    public void threeBody()
    {
        SceneManager.LoadScene(4);
    }
    public void threeBodySp()
    {
        SceneManager.LoadScene(5);
    }
    private void OnApplicationQuit()
    {
        //serielize the hashset containing names of simulations
        HashSet<string> save = savedSimulations.simulationList;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/simulationList.List");
       // Debug.Log("file created");
        bf.Serialize(file, save);
        file.Close();
    }

    public void quit()
    {
        Application.Quit();
    }
}
