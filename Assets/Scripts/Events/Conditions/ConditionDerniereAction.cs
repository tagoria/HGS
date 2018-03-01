using System;
using UnityEngine;

public class ConditionDerniereAction : EvenementAbstract.Condition
{
    private Type action;

    public ConditionDerniereAction(Type action)
    {
        this.action = action;
    }

    public override bool verify()
    {
        Horloge horloge = Component.FindObjectOfType<Horloge>();
        if (horloge.getDerniereActionRealisee() != null)
        {
        }
        return (horloge.getDerniereActionRealisee()!=null&& horloge.getDerniereActionRealisee().GetType().Equals(action)) ;
    }
}