

public abstract class StatusAbstract 
{
    public int duration;
    public int timeLeft;
    public readonly string nom;
    public readonly string description;
    public abstract void onStart();
    public virtual void onEnd()
    {
        Personnage.main.removeStatus(this);
    }
    public virtual void onTimePass()
    {
        timeLeft--;
        if (timeLeft == 0)
        {
            this.onEnd();
        }
    }
    public StatusAbstract(int duration,string nom,string description)
    {
        this.duration = duration;
        this.timeLeft = duration;
        this.nom = nom;
        this.description=description;
    }
}