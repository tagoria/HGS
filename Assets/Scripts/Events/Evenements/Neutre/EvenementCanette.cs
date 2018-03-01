using UnityEngine;
using System.Collections.Generic;

public class EvenementCanette : EvenementDeuxChoix 
{
    public static int CANETTE_BUE = 0;
    public static int CANETTE_JETEE = 1;
    public EvenementCanette() : base((int)EvenementsEnum.Canette,5, conditions, "La boire", "La jeter", "Canette oubliée", "Vous retrouvez une canette énergétique bombée derrière votre bureau pendant vos révisions",generateCreneau(5,6,7),"Une énergie nouvelle vous envahit +10 énergie","Vous décidez que ça n'en vaut pas le coup")
    {
        
    }
    private static List<EvenementAbstract.Condition> conditions = new List<EvenementAbstract.Condition>
        {
            new ConditionDerniereAction(typeof(Travailler)),new ConditionJoueurOccupe(false)
        };
    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Personnage>().augmenterEnergieActuelle(10);
        Horloge.instance.addToHistorique(new EventResult(this, CANETTE_BUE));
    }

    public override void realiserChoix2()
    {
        Horloge.instance.addToHistorique(new EventResult(this, CANETTE_JETEE));
    }
}