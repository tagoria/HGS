using UnityEngine;
using System.Collections.Generic;

public class Evenement2 : Evenement
{
    public Evenement2(List<Condition> conditions) : base(2, 10, conditions, "zut", "flute", "Epuisé", "Vous tombez de fatigue", "Vous vous réveillez en sursaut à 10 heures", "Vous vous réveillez en sursaut à 10 heures")
    {
    }
    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Horloge>().setCreneauActuel(5);
    }

    public override void realiserChoix2()
    {
        Component.FindObjectOfType<Horloge>().setCreneauActuel(5);
    }
}