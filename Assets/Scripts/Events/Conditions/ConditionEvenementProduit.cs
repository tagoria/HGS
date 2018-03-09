using System.Collections.Generic;
using Enums;

namespace Events.Conditions
{
    public class ConditionEvenementProduit : EvenementAbstract.Condition
    {
        private readonly EventResult eventResult;
        private readonly int _nbCreneaux;
        private readonly bool _produit;
        
        public ConditionEvenementProduit(EventResult eventResult, bool produit = true, int nbCreneaux = 99999)
        {
            this.eventResult = eventResult;
            this._produit = produit;
            this._nbCreneaux = nbCreneaux;
        }

        public ConditionEvenementProduit(Evenement evenement , int resultat , bool produit = true , int nbCreneaux = 99999) : this(new EventResult(evenement,resultat),produit,nbCreneaux)
        {
            
        }

        public override bool verify()
        {
            var resultHappened = Horloge.instance.LookForResult(eventResult, _nbCreneaux);
            return resultHappened == _produit;
        }
        public override bool Equals(object obj)
        {
            if (obj==null||obj.GetType() != typeof(ConditionEvenementProduit))
            {
                return false;
            }
                ConditionEvenementProduit condition = (ConditionEvenementProduit) obj;
                return condition._produit==_produit&&_nbCreneaux==condition._nbCreneaux&&eventResult.Equals(condition.eventResult);
        }

        public override int GetHashCode()
        {
            var hashCode = -474670356;
            hashCode = hashCode * -1521134295 + EqualityComparer<EventResult>.Default.GetHashCode(eventResult);
            hashCode = hashCode * -1521134295 + _nbCreneaux.GetHashCode();
            hashCode = hashCode * -1521134295 + _produit.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "ConditionEvenementProduit + evenement : "+this.eventResult.EnumEvenement+" resultat : "+eventResult.Result  +" nbcreneaux "+this._nbCreneaux+" s'est produit ? " +this._produit;
        }
    }
}