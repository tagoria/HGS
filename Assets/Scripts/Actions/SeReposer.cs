﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeReposer : Action {
    public override void Act()
    {
        Personnage.main.diminuerTravailActuel(10);
        Personnage.main.augmenterEnergieActuelle(10);
        Personnage.main.augmentersocialActuelle(5);
        base.Act();
    }

    // Use this for initialization
    private void Awake () {
        nom ="Se Reposer";
	}
	
	
}