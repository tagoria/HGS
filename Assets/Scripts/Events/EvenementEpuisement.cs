using System.Collections.Generic;
using Actions;
using Enums;
using Events.Conditions;
using UnityEngine;
using Action = Enums.Action;

namespace Events
{
    public class EvenementEpuisement : EvenementUnSeulChoix
    {
        private static readonly List<Condition> conditions = new List<Condition>
        {
            new ConditionDerniereAction(Action.Travailler),
            new ConditionJoueurOccupe(false)
        };

        private static readonly List<int> creneaux = new List<int>
        {
            1,
            2,
            3
        };

        public EvenementEpuisement() : base( Evenement.EvenementEpuisement, 10, conditions, "OK", "Epuisé",
            "Vous tombez de fatigue et vous réveillez en sursaut à 10 heures", creneaux)
        {
        }

        public override void realiserChoix1()
        {
            addEventResultToHistorique();
            Object.FindObjectOfType<Horloge>().setCreneauActuel(5);
        }
    }
}