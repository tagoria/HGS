using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstenteistePerk : Perk {
    public AbstenteistePerk() : base((int)PerksEnum.Abstenteiste, "Abstenteiste")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }
}
