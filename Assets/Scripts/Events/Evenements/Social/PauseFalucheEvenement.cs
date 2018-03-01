using System;
using System.Collections.Generic;

namespace Events.Evenements.Social
{
    public class PauseFalucheEvenement : EvenementDeuxChoix
    {
        public PauseFalucheEvenement() : 
            base(id: (int) EvenementsEnum.PauseFaluche, proba : 10, conditions : generateConditions(new ConditionJoueurOccupe(false)),
                choix1 : "Y aller", choix2 : "Ne pas y aller", titre : "Pause faluche",
                texte : "Vous êtes cordialement invité à vous reposer à la Faluche, y aller ?", 
                creneaux : generateCreneau(8), texteSiChoix1 : "C'était une bonne pinte", texteSiChoix2 : "Vous n'avez pas soif")
        {
        }

        public override Double getProba()
        {
            double add = Personnage.main.hasPerk(PerksEnum.Fetard) ? 10 : 0;
            add += Personnage.main.hasPerk(PerksEnum.Geek) ? -5 : 0;
            add += Personnage.main.hasPerk(PerksEnum.Stresse) ? -5 : 0;
            return base.getProba() + add;
        }
        public override void realiserChoix1()
        {
            Personnage.main.augmentersocialActuelle(20);
            Personnage.main.diminuerEnergieActuelle(5);
            Personnage.main.diminuerTravailActuel(5);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(1);
        }

        public override void realiserChoix2()
        {
            Personnage.main.diminuersocialActuelle(5);
        }
    }
}