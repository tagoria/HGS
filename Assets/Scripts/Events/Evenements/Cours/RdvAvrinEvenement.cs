using Enums;

namespace Events
{
    internal class RdvAvrinEvenement : EvenementDeuxChoix
    {
        public RdvAvrinEvenement() : base( Evenement.RdvAvrinEvenementSUITE,
            100, generateConditions(new Conditions.ConditionJoueurOccupe(false)),
            "Y aller", "Ne pas y aller", "Rdv Avrin",
            "Mr.Avrin vous attends dans son bureau. Y aller?", generateCreneau(9),
            "Vos absences sont clarifiées", "Avrin s'en souviendra")
        {
        }

        public override void realiserChoix1()
        {
            //je sais pas
        }

        public override void realiserChoix2()
        {
            //la non plus
        }
    }
}