using System.Collections.Generic;

namespace Events.Conditions
{
    public class ConditionEvenementProduit : EvenementAbstract.Condition
    {
        private readonly EventResult eventResult;
        private int nbCreneaux;
        private readonly bool produit;

        public ConditionEvenementProduit(EventResult eventResult, bool produit = true, int nbCreneaux = 99999)
        {
            this.eventResult = eventResult;
            this.produit = produit;
            this.nbCreneaux = nbCreneaux;
        }

        public override bool verify()
        {
            var resultHappened = Horloge.instance.LookForResult(eventResult, nbCreneaux);
            return resultHappened == produit;
        }
        public override bool Equals(object obj)
        {
            if (obj==null||obj.GetType() != typeof(ConditionEvenementProduit))
            {
                return false;
            }
                ConditionEvenementProduit condition = (ConditionEvenementProduit) obj;
                return condition.produit==produit&&nbCreneaux==condition.nbCreneaux&&eventResult.Equals(condition.eventResult);
        }

        public override int GetHashCode()
        {
            var hashCode = -474670356;
            hashCode = hashCode * -1521134295 + EqualityComparer<EventResult>.Default.GetHashCode(eventResult);
            hashCode = hashCode * -1521134295 + nbCreneaux.GetHashCode();
            hashCode = hashCode * -1521134295 + produit.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "ConditionEvenementProduit + evenement : "+this.eventResult.EnumEvenement+" resultat : "+eventResult.Result  +" nbcreneaux "+this.nbCreneaux+" s'est produit ? " +this.produit;
        }
    }
}