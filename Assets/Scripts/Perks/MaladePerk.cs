using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaladePerk : Perk {
    public MaladePerk() : base((int) PerksEnum.Malade, "Malade")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }
}
