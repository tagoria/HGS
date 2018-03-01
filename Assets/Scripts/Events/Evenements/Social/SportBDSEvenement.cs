using System.Collections.Generic;
using UnityEngine;

namespace Events.Evenements.Social
{
    public class SportBDSEvenement : EvenementDeuxChoix
    {
        public SportBDSEvenement() : base(id : (int)EvenementsEnum.SportBDS, proba : 20, conditions : generateConditions(new ConditionJoueurOccupe(false)), 
            choix1 : "Y aller", choix2 : "Ne pas y aller", titre : "Evenement sportif du BDS", texte:"Le BDS organise un événement sportif",
            creneaux : generateCreneau(7), texteSiChoix1 : "C'était bien", texteSiChoix2 : "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.instance.augmentersocialActuelle(15);
            Personnage.instance.diminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(Random.Range(2,4));
        }

        public override void realiserChoix2()
        {
            Personnage.instance.diminuersocialActuelle(5);
        }
    }
}