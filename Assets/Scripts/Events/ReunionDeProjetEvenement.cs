using Enums;
using Events.Conditions;

namespace Events
{
    public class ReunionDeProjetEvenement : EvenementDeuxChoix
    {
        public static readonly int REUNION_ASSISTE = 0;
        public static readonly int REUNION_SECHE = 1;

        public ReunionDeProjetEvenement() : base(Evenement.ReunionDeProjetEvenement, 10, generateConditions(
                new HasStatusCondition(StatusEnum.JourFerie, false),
                new ConditionEvenementProduit(new EventResult(Evenement.Conference,
                    Conference.CONFERENCE_ASSISTE)))
            , "y aller", "ne pas y aller", "réunion projet",
            "Vous avez une réunion de projet prévu maintenant", generateCreneau(9), "C'était une bonne réunion",
            "Pas aujourd'hui")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.augmenterTravailActuel(25);
            Personnage.Player.instance.diminuerEnergieActuelle(15);
            addResultatToHistorique(REUNION_ASSISTE);
            Horloge.instance.setCreneauActuel(10);
        }

        public override void realiserChoix2()
        {
            //rien
            addResultatToHistorique(REUNION_SECHE);
        }
    }
}