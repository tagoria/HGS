using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Perk2 : Perk {
    public override void appliquer()
    {
        Personnage.main.maxTravailPerso *= 15f;
    }
    public Perk2(int id) : base(id,"Perk exemple2")
    {

    }

}
