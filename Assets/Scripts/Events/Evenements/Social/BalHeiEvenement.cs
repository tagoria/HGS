namespace Events.Evenements.Social
{
    public class BalHeiEvenement : EvenementDeuxChoix
    {
        public BalHeiEvenement() : base(id : (int)EvenementsEnum.BalHEI, proba : 5, conditions : generateConditions(new ConditionJoueurOccupe(false)), 
            choix1 : "Y aller", choix2 : "Ne pas y aller", titre : "Bal HEI", texte:"HEI organise un bal",
            creneaux : generateCreneau(10), texteSiChoix1 : "C'était bien", texteSiChoix2 : "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.instance.augmentersocialActuelle(15);
            Personnage.instance.diminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(2);
        }

        public override void realiserChoix2()
        {
            Personnage.instance.diminuersocialActuelle(5);
        }
    }
}