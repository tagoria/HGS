using Enums;
using Events.Conditions;

namespace Events
{
    public class OuvertureCulturelleEvenement : EvenementDeuxChoix
    {
        public static readonly int OUVERTURE_ASSISTE = 0;
        public static readonly int OUVERTURE_SECHE = 1;

        public OuvertureCulturelleEvenement() : base(Evenement.OuvertureCulturelleEvenement, 10,
            generateConditions(new HasStatusCondition(StatusEnum.JourFerie, false)), "y aller", "ne pas y aller",
            "ouverture culturelle",
            "Vous avez ouverture culturelle", generateCreneau(9), "Vous avez appris plein de chose", "Pas aujourd'hui")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterTravailActuel(25);
            Personnage.Player.instance.DiminuerEnergieActuelle(15);
            addResultatToHistorique(OUVERTURE_ASSISTE);
            Horloge.instance.setCreneauActuel(10);
        }

        public override void realiserChoix2()
        {
            //rien
            addResultatToHistorique(OUVERTURE_SECHE);
        }
    }
}