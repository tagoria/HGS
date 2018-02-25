using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionJoueurOccupe : EvenementAbstract.Condition {
    public override bool verify()
    {
        return( (condition && Personnage.main.occuppe) || (!condition && !Personnage.main.occuppe));
    }
    private bool condition;
    public ConditionJoueurOccupe(bool occupe)
    {
        this.condition = occupe;
    }
}
