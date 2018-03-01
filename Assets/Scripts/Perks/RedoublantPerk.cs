using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoublantPerk : Perk {
    public RedoublantPerk() : base((int) PerksEnum.Redoublant, "Redoublant")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }
}
