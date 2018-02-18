

public class StatusJourFerie: StatusAbstract
{
    public StatusJourFerie() : base(12-Horloge.instance.getCreneauActuel(),"Jour férié","Aujourd'hui c'est férié donc pas de cours")
    {
    }

    public override void onEnd()
    {
        Botin.instance.ferie = false;
        base.onEnd();
    }

    public override void onStart()
    {
        Botin.instance.ferie = true ;
    }
    public override string ToString()
    {
        return this.nom+" : "+this.description+"\n temps restant : "+this.timeLeft*2+" heures";
    }

    
}