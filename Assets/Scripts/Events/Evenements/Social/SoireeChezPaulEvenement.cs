using System.Collections.Generic;
using Enums;
using Events;
using Events.Conditions;

namespace Events
{

    public class SoireeChezPaulEvenement : EvenementDeuxChoix
    {
        public SoireeChezPaulEvenement() : base(Evenement.SoireeChezPaulEvenement, (int) ProbaEnum.SoireeChezPaul,
            generateConditions(new ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Bar Mitzva chez Paul",
            "Paul fête le premier jour du reste de notre vie, il t'a invité, mais tu ne le connais pas trop...",
            generateCreneau(10), "C'est l'occasion de se faire un ami", "Paule'temps")
        {
        }


        public override double getProba()
        {
            double add = Personnage.Player.instance.HasPerk(PerksEnum.FetardPerk) ? 10 : 0;
            add += Personnage.Player.instance.HasPerk(PerksEnum.GeekPerk) ? -5 : 0;
            add += Personnage.Player.instance.HasPerk(PerksEnum.StressePerk) ? -5 : 0;
            return base.getProba() + add;
        }

        private int TempsAleatoire()
        {
            int a = 0;
            if (Personnage.Player.instance.HasPerk(PerksEnum.FetardPerk))
            {
                // J'ai hésité à mettre un random, pour finir, je gère selon l'énergie du joueur
                if ((int) Personnage.Player.instance.GetEnergieActuelle() <= 20)
                {
                }

                if ((int) Personnage.Player.instance.GetEnergieActuelle() >= 20)
                {
                    a++;
                }

                if ((int) Personnage.Player.instance.GetEnergieActuelle() >= 50)
                {
                    a++;
                }
            }

            return a;
        }


        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterSocialActuel(30);
            Personnage.Player.instance.DiminuerEnergieActuelle(10);
            Personnage.Player.instance.DiminuerTravailActuel(5);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(2 + TempsAleatoire());
        }

        public override void realiserChoix2()
        {
            Personnage.Player.instance.DiminuerSocialActuel(5);
        }
    }
}
