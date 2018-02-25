using UnityEngine;
using UnityEditor;

public class RdvMedecinStatus : StatusAbstract
{
    public RdvMedecinStatus(int duration) : base(duration, "Rdv chez le médecin", "Vous avez rdv chez le médecin", (int)StatusEnum.RdvMedecin,false)
    {

    }

    public override void onStart()
    {
        //rien
    }
    public override string ToString()
    {
        return "Vous avez rdv chez le médecin dans "+this.timeLeft*2+" heures";
    }
    public override void onEnd()
    {
        GenerationEvenement.instance.afficher(new RdvMedecinEvenement());
        base.onEnd();
    }
}