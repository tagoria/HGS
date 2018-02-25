public class RDVAvrinStatus : StatusAbstract
{
    public RDVAvrinStatus() : base(duration:Horloge.getCreneauxLeftTo(1,9), nom:"Rdv Avrin", description:"Vous avez rdv avec Avrin", id:(int)StatusEnum.RdvAvrin, addable:false)
    {
    }
    public override string ToString()
    {
        return "Vous avez rdv avec Avrin dans " + this.timeLeft * 2 + " heures";
    }
    public override void onStart()
    {
        //rien
    }
    public override void onEnd()
    {
        Botin.instance.essayerForcerEvenement(new RdvAvrinEvenement());
        base.onEnd();
    }
}