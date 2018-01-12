using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour  {

    public abstract void Act();
    protected string nom;
    public string GetNom()
    {
        return nom;
    }
}
