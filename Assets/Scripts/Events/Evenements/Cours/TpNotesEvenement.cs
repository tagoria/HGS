using UnityEngine;
using UnityEditor;

public class TpNotesEvenement : EvenementDeuxChoix
{


    public static readonly int TP_ASSISTE = 0;
    public static readonly int TP_SECHE = 1;
    public TpNotesEvenement() : base((int)EvenementsEnum.TpNotes, 20, generateConditions(
        new HasStatusCondition(StatusEnum.JourFerie,false)), "y aller", "ne pas y aller", "TP notés",
        "Vous avez tp", generateCreneau(7), "Vous aurez une bonne note", "Pas aujourd'hui")
    {
    }

    public override void realiserChoix1()
    {
        Personnage.instance.augmenterTravailActuel(25);
        Personnage.instance.diminuerEnergieActuelle(25);
        addResultatToHistorique(TP_ASSISTE);
        Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(2);
    }

    public override void realiserChoix2()
    {
        //rien
        Personnage.instance.diminuerTravailActuel(15);
        addResultatToHistorique(TP_SECHE);
    }
}