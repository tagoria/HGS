using System;
using Enums;
using Events.Conditions;
using Status;

namespace Events
{
    public class AbsenceBizarreEvenement : EvenementDeuxChoix
    {
        public AbsenceBizarreEvenement() : base( Evenement.AbsenceBizarreEvenement, 10,
            generateConditions(new ConditionJoueurOccupe(false), new HasStatusCondition(StatusEnum.JourFerie)),
            "prendre RDV", "tant pis", "Absence bizarre",
            "Il semblerait que vous ne cessiez d’être noté absent en cours d’espagnol alors que vous n’êtes même pas inscrit" +
            " dans ce cours." +
            " Un RDV avec MR.AVRIN semble nécessaire pour corrigé ce problème au plus vite. Votre RDV est établi au lendemain à 16H",
            generateCreneau(4, 5, 6, 7, 8, 9), "Vous avez rdv demain à 16h", "pas le temps pour ces conneris")
        {
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AjouterStatus(new RDVAvrinStatus());
        }

        public override void realiserChoix2()
        {
            throw new NotImplementedException();
        }
    }
}