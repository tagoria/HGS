using UnityEngine;

namespace Events.Evenements.Social
{
    public class AfterworkHeiEvenement : EvenementDeuxChoix
    {
        public AfterworkHeiEvenement() : base(id : (int)EvenementsEnum.AfterworkHei, proba : 20, conditions : generateConditions(new ConditionJoueurOccupe(false)), 
            choix1 : "Y aller", choix2 : "Ne pas y aller", titre : "Afterwork HEI", texte:"Une association organise un AfterWork",
            creneaux : generateCreneau(10), texteSiChoix1 : "C'était bien", texteSiChoix2 : "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.main.augmentersocialActuelle(15);
            Personnage.main.diminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(Random.Range(1,3));
        }

        public override void realiserChoix2()
        {
            Personnage.main.diminuersocialActuelle(5);
        }
    }
}