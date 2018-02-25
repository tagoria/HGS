using UnityEngine;
using System.Collections.Generic;

public class EvenementEpuisement : EvenementUnSeulChoix
{
    public EvenementEpuisement() : base((int) EvenementsEnum.Epuisement, 10, conditions: conditions, choix1: "OK", titre: "Epuisé", texte: "Vous tombez de fatigue et vous réveillez en sursaut à 10 heures", creneau: creneaux)
    {
    }
    
    private static List<EvenementAbstract.Condition> conditions = new List<EvenementAbstract.Condition>
        {
            new ConditionDerniereAction(typeof(Travailler)), new ConditionJoueurOccupe(false)
        };
    private static List<int> creneaux = new List<int>
    {
        1,2,3
    };
    public override void realiserChoix1()
    {
        addEventResultToHistorique();
        Component.FindObjectOfType<Horloge>().setCreneauActuel(5);
    }

}