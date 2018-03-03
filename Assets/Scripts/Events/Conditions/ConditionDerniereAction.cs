using System;
using Object = UnityEngine.Object;

namespace Events.Conditions
{
    public class ConditionDerniereAction : EvenementAbstract.Condition
    {
        private readonly Type action;

        public ConditionDerniereAction(Type action)
        {
            this.action = action;
        }

        public override bool verify()
        {
            var horloge = Object.FindObjectOfType<Horloge>();
            if (horloge.getDerniereActionRealisee() != null)
            {
            }

            return horloge.getDerniereActionRealisee() != null &&
                   horloge.getDerniereActionRealisee().GetType().Equals(action);
        }
    }
}