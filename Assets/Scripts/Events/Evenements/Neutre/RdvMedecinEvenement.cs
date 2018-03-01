using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class RdvMedecinEvenement : EvenementUnSeulChoix
{

    public RdvMedecinEvenement() : base((int)EvenementsEnum.RdvMedecin, 100, generateConditions(new ConditionJoueurOccupe(false)),"Ok", "Rdv Medecin", "Rdv Medecin",creneauInit )
    {
    }
    private static List<int> creneauInit = new List<int>
    {
        7

    };
    public override void realiserChoix1()
    {
        Botin.instance.supprimerEvenementSurToutLesCreneaux(this);
        Personnage.instance.removeStatus((int)StatusEnum.Grippe);
        Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 1);
        addEventResultToHistorique();
    }
}