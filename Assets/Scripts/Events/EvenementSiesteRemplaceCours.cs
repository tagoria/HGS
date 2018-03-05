using Enums;
using Events.Conditions;

namespace Events
{
    public class EvenementSiesteRemplaceCours : EvenementUnSeulChoix
    {
        public EvenementSiesteRemplaceCours() : base( Evenement.EvenementSiesteRemplaceCours, 5,
            generateConditions(new ConditionJoueurOccupe(false)),
            "ok", "seche sauvage", "au dernier moment vous décidez de sécher le cours et de faire une sieste",
            generateCreneau(3, 4, 5, 6, 7, 8, 9, 10))
        {
        }

        public override void realiserChoix1()
        {
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(1);
        }
    }
}