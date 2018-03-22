using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Events.Conditions
{
    public class ConditionDerniereAction : EvenementAbstract.Condition
    {
        private readonly Enums.Action action;

        public ConditionDerniereAction(Enums.Action action)
        {
            this.action = action;
        }

        public override bool verify()
        {
            var horloge = Object.FindObjectOfType<Horloge>();
            return horloge.getDerniereActionRealisee() == action;
        }
        public override bool Equals(object obj)
        {
            if (obj==null||obj.GetType() != typeof(ConditionDerniereAction))
            {
                return false;
            }
            ConditionDerniereAction condition = (ConditionDerniereAction) obj;
            return action == condition.action;

        }

        public override int GetHashCode()
        {
            return -1387187753 + (int)action;
        }
        public override string ToString()
        {
            return "ConditionDerniereAction , action = "+this.action;
        }
    }
}