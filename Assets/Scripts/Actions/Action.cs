using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour  {

    private void Start()
    {
        horloge = FindObjectOfType<Horloge>();
    }
    private Horloge horloge;
    public virtual void Act()
    {
        horloge.setDerniereActionRealisee(this);
        horloge.avancerDunCreneau();
        
    }
    protected string nom;
    public string GetNom()
    {
        return nom;
    }
}
