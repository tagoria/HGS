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
    }
}