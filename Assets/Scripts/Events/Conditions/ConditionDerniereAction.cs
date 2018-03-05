using System;
using System.Collections.Generic;
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
        public override bool Equals(object obj)
        {
            if (obj==null||obj.GetType() != typeof(ConditionDerniereAction))
            {
                return false;
            }
            else
            {
                ConditionDerniereAction condition = (ConditionDerniereAction) obj;
                return action == condition.action;
            }

        }

        public override int GetHashCode()
        {
            return -1387187753 + EqualityComparer<Type>.Default.GetHashCode(action);
        }
        public override string ToString()
        {
            return "ConditionDerniereAction , action = "+this.action;
        }
    }
}