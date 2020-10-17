using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//object of this class holds the given CbodySpoof array

[System.Serializable]
public class CBSarrayHolder 
{
    public string name;
    public CbodySpoof[] CBS;

    public CBSarrayHolder(string name,CbodySpoof[] CBS)
    {
        this.name = name;
        this.CBS = CBS;
    }
}
