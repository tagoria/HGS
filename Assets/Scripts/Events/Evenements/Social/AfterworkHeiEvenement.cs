using Enums;
using Events.Conditions;
using UnityEngine;

namespace Events
{
    public class AfterworkHeiEvenement : EvenementDeuxChoix
    {
        public AfterworkHeiEvenement() : base( Evenement.AfterworkHeiEvenement, 20,
            generateConditions(new ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Afterwork HEI", "Une association organise un AfterWork",
            generateCreneau(10), "C'était bien", "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(15);
            Personnage.Player.instance.DiminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(Random.Range(1, 3));
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.DiminuerSocialActuel(5);
        }
    }
}