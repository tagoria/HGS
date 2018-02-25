using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeekPerk : Perk {
    public GeekPerk() : base((int)PerksEnum.Geek,"Geek")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }

}
