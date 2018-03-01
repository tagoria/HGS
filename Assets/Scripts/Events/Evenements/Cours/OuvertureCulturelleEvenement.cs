using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class OuvertureCulturelleEvenement : EvenementDeuxChoix
{
    public static readonly int OUVERTURE_ASSISTE = 0;
    public static readonly int OUVERTURE_SECHE = 1;
    public OuvertureCulturelleEvenement() : base((int)EvenementsEnum.OuvertureCulturelle, 10,
        generateConditions(new HasStatusCondition(StatusEnum.JourFerie,false)), "y aller", "ne pas y aller", "ouverture culturelle",
        "Vous avez ouverture culturelle", generateCreneau(9), "Vous avez appris plein de chose", "Pas aujourd'hui")
    {
    }

    public override void realiserChoix1()
    {
        Personnage.instance.augmenterTravailActuel(25);
        Personnage.instance.diminuerEnergieActuelle(15);
        addResultatToHistorique(OUVERTURE_ASSISTE);
        Horloge.instance.setCreneauActuel(10);
    }

    public override void realiserChoix2()
    {
        //rien
        addResultatToHistorique(OUVERTURE_SECHE);
    }
}