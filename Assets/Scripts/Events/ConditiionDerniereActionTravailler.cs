using UnityEngine;
using UnityEditor;

public class ConditionDerniereActionTravailler : Evenement.Condition
{
    private Action action;

    public ConditionDerniereActionTravailler(Action action)
    {
        this.action = action;
    }

    public override bool verify()
    {
        Horloge horloge = Component.FindObjectOfType<Horloge>();
        if (horloge.getDerniereActionRealisee() != null)
        {
            Debug.Log(horloge.getDerniereActionRealisee().GetNom());
        }
        return (horloge.getDerniereActionRealisee()!=null&& horloge.getDerniereActionRealisee().GetNom().Equals(action.GetNom())) ;
    }
}