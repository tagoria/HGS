
using System.Collections.Generic;

public class DejeunerAuRuEvenement : EvenementDeuxChoix
{
    public DejeunerAuRuEvenement() : base(id:(int)EvenementsEnum.DejeunerAuRu, proba:15, conditions:generateConditions(
        new ConditionEvenementProduit(new EventResult(EvenementsEnum.CoursMatin,EvenementCoursMatin.COURS_ASSISTE),true,1)),
        choix1:"Y aller", choix2:"Ne pas y aller", titre:"Dejeuner au RU", texte:"aller déjeuner au RU?", creneaux:generateCreneau(6),
        texteSiChoix1:"C'était bon", texteSiChoix2:"Pas le temps")
    {
    }

    public override void realiserChoix1()
    {
        Personnage.instance.augmentersocialActuelle(15);
        Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(1);
    }

    public override void realiserChoix2()
    {
        Personnage.instance.diminuersocialActuelle(5);
    }
}