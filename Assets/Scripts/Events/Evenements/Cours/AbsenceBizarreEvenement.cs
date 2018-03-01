
using System.Collections.Generic;

public class AbsenceBizarreEvenement : EvenementDeuxChoix
{
    public AbsenceBizarreEvenement() : base(id: (int)EvenementsEnum.AbsenceBizarre, proba:10,
        conditions : generateConditions(new ConditionJoueurOccupe(false),new HasStatusCondition(StatusEnum.JourFerie)),
        choix1 : "prendre RDV", choix2:"tant pis", titre:"Absence bizarre", texte:"Il semblerait que vous ne cessiez d’être noté absent en cours d’espagnol alors que vous n’êtes même pas inscrit" +
        " dans ce cours." +
        " Un RDV avec MR.AVRIN semble nécessaire pour corrigé ce problème au plus vite. Votre RDV est établi au lendemain à 16H",
        creneaux:generateCreneau(4,5,6,7,8,9), texteSiChoix1:"Vous avez rdv demain à 16h", texteSiChoix2:"pas le temps pour ces conneris")
    {
    }

    public override void realiserChoix1()
    {
        Personnage.main.ajouterStatus(new RDVAvrinStatus());
    }

    public override void realiserChoix2()
    {
        throw new System.NotImplementedException();
    }
}