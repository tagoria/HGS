using Enums;
using Events.Conditions;

namespace Events
{
    public class DejeunerAuRuEvenement : EvenementDeuxChoix
    {
        public DejeunerAuRuEvenement() : base(Evenement.DejeunerAuRuEvenement, 15, generateConditions(
                new ConditionEvenementProduit(
                    new EventResult(Evenement.EvenementCoursMatin, EvenementCoursMatin.COURS_ASSISTE), true, 1)),
            "Y aller", "Ne pas y aller", "Dejeuner au RU", "aller déjeuner au RU?", generateCreneau(6),
            "C'était bon", "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(15);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(1);
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.diminuerSocialActuel(5);
        }
    }
}