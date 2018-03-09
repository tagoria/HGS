using System.Collections.Generic;
using Enums;
using Events.Conditions;

namespace Events
{
    public class TournoiSportifEvenement : EvenementDeuxChoix
    {
        
        public TournoiSportifEvenement() : base(id : Evenement.TournoisSportifEvenement, proba : ProbaEnum.TournoiSportif,
            conditions : generateConditions(new HasPerkCondition(PerksEnum.SportifPerk)), choix1 : "y aller", choix2 : "ne pas y aller",
            titre : "Tournoi sportif HEI", texte : "Votre équipe a besoin de vous pour gagner ce tournoi",
            creneaux : generateCreneau(7), texteSiChoix1 : "Y aller", texteSiChoix2 : "Les abandonner")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(25);
            Personnage.Player.instance.DiminuerEnergieActuelle(20);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(3);
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.DiminuerSocialActuel(5);
        }
    }
}