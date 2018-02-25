using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EvenementSiesteRemplaceCours : EvenementUnSeulChoix
{
    public EvenementSiesteRemplaceCours() : base((int) EvenementsEnum.SiesteRemplaceCours, 5, generateConditions(new ConditionJoueurOccupe(false)),
        "ok", "seche sauvage", "au dernier moment vous décidez de sécher le cours et de faire une sieste", generateCreneau(3,4,5,6,7,8,9,10))
    {
    }

    public override void realiserChoix1()
    {
        throw new System.NotImplementedException();
    }
}