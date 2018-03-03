﻿using Enums;
using Events.Conditions;

namespace Events
{
    public class PauseFalucheEvenement : EvenementDeuxChoix
    {
        public PauseFalucheEvenement() :
            base( Evenement.PauseFalucheEvenement, 10, generateConditions(new ConditionJoueurOccupe(false)),
                "Y aller", "Ne pas y aller", "Pause faluche",
                "Vous êtes cordialement invité à vous reposer à la Faluche, y aller ?",
                generateCreneau(8), "C'était une bonne pinte", "Vous n'avez pas soif")
        {
        }

        public override double getProba()
        {
            double add = Personnage.Player.instance.hasPerk(PerksEnum.Fetard) ? 10 : 0;
            add += Personnage.Player.instance.hasPerk(PerksEnum.Geek) ? -5 : 0;
            add += Personnage.Player.instance.hasPerk(PerksEnum.Stresse) ? -5 : 0;
            return base.getProba() + add;
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(20);
            Personnage.Player.instance.diminuerEnergieActuelle(5);
            Personnage.Player.instance.diminuerTravailActuel(5);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(1);
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.diminuerSocialActuel(5);
        }
    }
}