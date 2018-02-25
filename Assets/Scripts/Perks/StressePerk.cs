using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressePerk : Perk {
    public StressePerk() : base((int)PerksEnum.Stresse, "Stressé")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }

}
