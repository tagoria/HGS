using System.Collections.Generic;

namespace Events.Evenements.Social
{
    public class SortieSportEvenement : EvenementDeuxChoix
    {
        public SortieSportEvenement() : base(id: (int) EvenementsEnum.SortieSport, proba : 5, conditions : generateConditions(new ConditionJoueurOccupe(false)),
            choix1 : "Y aller", choix2 : "Ne pas y aller", titre : "Sortie sportive", texte : "Aller faire du sport", creneaux : generateCreneau(7),
            texteSiChoix1 : "Vous rentrez épuisé mais content de vous", texteSiChoix2 : "Tout mais pas du sport!")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.instance.augmentersocialActuelle(30);
            Personnage.instance.diminuerEnergieActuelle(25);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(2);
        }

        public override void realiserChoix2()
        {
            //rien
        }
    }
}