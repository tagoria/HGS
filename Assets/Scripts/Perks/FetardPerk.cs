using UnityEngine;
using UnityEditor;

public class FetardPerk : Perk
{
    public FetardPerk() : base((int)PerksEnum.Fetard,"Fetard")
    {
    }

    public override void appliquer()
    {
        throw new System.NotImplementedException();
    }
}