using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travailler : Action
{
    private void Awake()
    {
        nom = "Travailler";   
    }
    public override void Act()
    {
        Personnage.instance.augmenterTravailActuel(10);
        Personnage.instance.diminuerEnergieActuelle(10);
        base.Act();
    }
}
