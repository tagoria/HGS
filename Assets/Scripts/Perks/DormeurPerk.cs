using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormeurPerk : Perk {
    public DormeurPerk() : base((int)PerksEnum.Dormeur, "Dormeur")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }

}
