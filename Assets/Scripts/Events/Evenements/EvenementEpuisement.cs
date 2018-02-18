using UnityEngine;
using System.Collections.Generic;

public class EvenementEpuisement : EvenementUnSeulChoix
{

    public EvenementEpuisement() : base(2, 10, conditions: conditions, choix1: "OK", titre: "Epuisé", texte: "Vous tombez de fatigue et vous réveillez en sursaut à 10 heures")
    {
    }
    private static List<Evenement.Condition> conditions = new List<Evenement.Condition>
        {
            new ConditionDerniereAction(typeof(Action1)), new ConditionJoueurOccupe(false)
        };
    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Horloge>().setCreneauActuel(5);
    }

}