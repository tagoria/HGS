using UnityEngine;
using UnityEditor;

public class ConferenceHeiEvenement : EvenementDeuxChoix
{
    public static readonly int CONFERENCE_ASSISTE = 0;
    public static readonly int CONFERENCE_SECHE = 1;
    public ConferenceHeiEvenement() : base((int)EvenementsEnum.ConferenceHeiEvenement, 5, generateConditions(
        new HasStatusCondition(StatusEnum.JourFerie,false)), "y aller", "ne pas y aller", "TP notés",
        "Vous avez tp", generateCreneau(9), "Vous aurez une bonne note", "Pas aujourd'hui")
    {
    }

    public override void realiserChoix1()
    {
        Personnage.instance.augmenterTravailActuel(25);
        Personnage.instance.diminuerEnergieActuelle(15);
        addResultatToHistorique(CONFERENCE_ASSISTE);
        Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 1);
    }

    public override void realiserChoix2()
    {
        //rien
        addResultatToHistorique(CONFERENCE_SECHE);
    }
}