using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EventResult : EqualityComparer<EventResult> 
{
    public EventResult(EvenementsEnum evenement , int result=0)
    {
        this._creneauDebut = Horloge.instance.getCreneauActuel();
        this.evenement=evenement;
        this.result = result;
    }

    public EventResult(EvenementAbstract evenementAbstract, int result=0) : this((EvenementsEnum) evenementAbstract.getId(),result)
    {
        
    }
    private readonly EvenementsEnum evenement;
    private readonly int result;

    public EvenementsEnum Evenement
    {
        get
        {
            return evenement;
        }
    }

    public int Result
    {
        get
        {
            return result;
        }
    }

    private readonly int _creneauDebut;


    public int GetCreneauDebut()
    {
        return _creneauDebut;
    }
    public override int GetHashCode(EventResult obj)
    {
        return this.Result*100000 + (int)this.Evenement;
    }

    public override bool Equals(EventResult x, EventResult y)
    {
        return x.Evenement.Equals(y.Evenement) && x.Result == y.Result;
    }
}