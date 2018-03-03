﻿using Enums;
using Events.Conditions;

namespace Events
{
    public class SortieSportEvenement : EvenementDeuxChoix
    {
        public SortieSportEvenement() : base(Evenement.SortieSportEvenement, 5,
            generateConditions(new ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Sortie sportive", "Aller faire du sport", generateCreneau(7),
            "Vous rentrez épuisé mais content de vous", "Tout mais pas du sport!")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(30);
            Personnage.Player.instance.diminuerEnergieActuelle(25);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(2);
        }

        public override void realiserChoix2()
        {
            //rien
        }
    }
}