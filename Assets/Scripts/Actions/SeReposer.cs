using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeReposer : Action {
    public override void Act()
    {
        Personnage.instance.diminuerTravailActuel(10);
        Personnage.instance.augmenterEnergieActuelle(10);
        Personnage.instance.augmentersocialActuelle(5);
        base.Act();
    }

    // Use this for initialization
    private void Awake () {
        nom ="Se Reposer";
	}
	
	
}
