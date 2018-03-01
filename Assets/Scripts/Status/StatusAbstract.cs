

using System.Collections.Generic;
using UnityEngine;

public abstract class StatusAbstract 
{
    protected int duration;
    protected int timeLeft;
    public readonly string nom;
    public readonly string description;
    public readonly int id;
    public abstract void onStart();
    private bool addable;

    public bool isAddable()
    {
        return addable;
    }

    public virtual void onEnd()
    {
        Personnage.instance.removeStatus(this.id);
    }
    public virtual void onTimePass()
    {
        timeLeft--;
        if (timeLeft == 0)
        {
            this.onEnd();
        }
    }
    public StatusAbstract(int duration,string nom,string description,int id,bool addable=true)
    {
        this.duration = duration;
        this.timeLeft = duration;
        this.nom = nom;
        this.description=description;
        this.id = id;
        this.addable = addable;
    }
    public override string ToString()
    {
        return this.nom + " : " + this.description + " temps restant : " + this.timeLeft * 2 + " heures";
    }
    public void add(StatusAbstract status)
    {
        if (status.addable)
        {
            this.timeLeft += status.timeLeft;
        }
        else
        {
            Debug.Log("trying to add " + this.GetType() + " with " + status.GetType());
        }
    }
    public int getTimeLeft()
    {
        return timeLeft;
    }
    public int getDuration()
    {
        return duration;
    }

}