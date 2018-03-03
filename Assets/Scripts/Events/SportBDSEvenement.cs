using Enums;
using Events.Conditions;
using UnityEngine;

namespace Events
{
    public class SportBDSEvenement : EvenementDeuxChoix
    {
        public SportBDSEvenement() : base(Evenement.SportBDSEvenement, 20,
            generateConditions(new ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Evenement sportif du BDS", "Le BDS organise un événement sportif",
            generateCreneau(7), "C'était bien", "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(15);
            Personnage.Player.instance.diminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(Random.Range(2, 4));
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.diminuerSocialActuel(5);
        }
    }
}