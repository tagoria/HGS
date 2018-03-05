using System.Collections.Generic;
using Enums;

namespace Events
{
    public class Conference : EvenementDeuxChoix
    {
        public static readonly int CONFERENCE_ASSISTE = 0;

        public static readonly int CONFERENCE_PAS_ASSISTE = 1;
        // id, proba, conditions, texteChoix1, texteChoix2, Titre, Description, DescriptionChoix1, Description Choix2

        public Conference() : base( Evenement.Conference, 5,
            generateConditions(new Conditions.ConditionJoueurOccupe(false),new Conditions.HasStatusCondition(StatusEnum.JourFerie)), "Oui", "Non", "Conférence",
            "Vous êtes convié à une conférence sur la Cyber-sécurité. Souhaitez-vous y aller ?",
            generateCreneau(8, 9),
            "La séance fut instructive, saviez-vous que la première défense contre les cyberattaques est de fermer son bureau à clef ? Malin.",
            "La séance est facultative, ça tombe bien vous n'y allez pas")
        {
        }

        public override void realiserChoix1()
        {
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(1);
            Personnage.Player.instance.diminuerEnergieActuelle(10);
            addResultatToHistorique(CONFERENCE_ASSISTE);
        }

        public override void realiserChoix2()
        {
            // Nothing
            addResultatToHistorique(CONFERENCE_PAS_ASSISTE);
        }
    }
}