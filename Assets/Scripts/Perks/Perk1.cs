using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Perk1 : Perk
{
    public Perk1(int id):base(id,"Perk exemple 1")
    {
        
    }

    public override void appliquer()
    {
        Personnage.main.maxEnergiePerso *= 15f;

    }

}
