using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action2 : Action {
    public override void Act()
    {
        Personnage.main.diminuerTravailActuel(10);
        Personnage.main.augmenterEnergieActuelle(10);
        Personnage.main.augmentersocialActuelle(5);
    }

    // Use this for initialization
    private void Awake () {
        nom ="Se Reposer";
	}
	
	
}
