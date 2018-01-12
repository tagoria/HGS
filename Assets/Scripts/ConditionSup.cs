using UnityEngine;
using UnityEditor;

public class ConditionSup : Conditions
{

    public float minimum;
    private string valeurCompare;
    public override bool verify()
    {
        Sauvegarde sauvegarde = GameObject.FindGameObjectWithTag(Sauvegarde.SAUVEGARDEFLOTTANTE).GetComponent<Sauvegarde>();
        return (float)sauvegarde.get(valeurCompare) > minimum;
    }
    
    public ConditionSup(float mini,string compare)
    {
        minimum = mini;
        valeurCompare=compare;
    }
}