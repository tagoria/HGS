using System.Collections.Generic;

namespace Events
{
    public abstract class EvenementUnSeulChoix : EvenementAbstract
    {
        public EvenementUnSeulChoix(Enums.Evenement id, float proba, List<Condition> conditions, string choix1, string titre,
            string texte, List<int> creneau) : base(id, proba, conditions, choix1, titre, texte, creneau)
        {
        }

        public override bool isEvenmentDeuxChoix()
        {
            return false;
        }

        protected void addEventResultToHistorique()
        {
            Horloge.instance.addToHistorique(new EventResult(this));
        }
    }
}