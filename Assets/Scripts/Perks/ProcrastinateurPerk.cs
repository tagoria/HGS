using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcrastinateurPerk : Perk {
    public ProcrastinateurPerk() : base((int)PerksEnum.Procrastinateur,"Procristanateur")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }
}
