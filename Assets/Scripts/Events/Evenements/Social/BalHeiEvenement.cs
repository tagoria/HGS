using Enums;
using Events.Conditions;

namespace Events
{
    public class BalHeiEvenement : EvenementDeuxChoix
    {
        public BalHeiEvenement() : base(Evenement.BalHeiEvenement, 5,
            generateConditions(new ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Bal HEI", "HEI organise un bal",
            generateCreneau(10), "C'était bien", "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(15);
            Personnage.Player.instance.DiminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(2);
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.DiminuerSocialActuel(5);
        }
    }
}