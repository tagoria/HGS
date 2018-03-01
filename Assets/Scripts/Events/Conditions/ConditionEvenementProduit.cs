public class ConditionEvenementProduit : EvenementAbstract.Condition
{
    private EventResult eventResult;
    private bool produit;
    private int nbCreneaux;
    public ConditionEvenementProduit(EventResult eventResult,bool produit=true,int nbCreneaux=99999)
    {
        this.eventResult = eventResult;
        this.produit = produit;
        nbCreneaux = this.nbCreneaux;
    }

    public override bool verify()
    {
        bool resultHappened = Horloge.instance.LookForResult(eventResult,nbCreneaux);
        return resultHappened == produit;
    }
}