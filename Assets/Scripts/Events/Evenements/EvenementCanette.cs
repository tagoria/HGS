using UnityEngine;
using System.Collections.Generic;

public class EvenementCanette : EvenementDeuxChoix 
{
    public EvenementCanette() : base(1,1, conditions, "La boire", "La jeter", "Canette oubliée", "Vous retrouvez une canette énergétique bombée derrière votre bureau pendant vos révisions","Une énergie nouvelle vous envahit +10 énergie","Vous décidez que ça n'en vaut pas le coup")
    {
        
    }
    private static List<Evenement.Condition> conditions = new List<Evenement.Condition>
        {
            new ConditionDerniereAction(typeof(Action1)),new ConditionJoueurOccupe(false)
        };
    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Personnage>().augmenterEnergieActuelle(10);
    }

    public override void realiserChoix2()
    {
        //rien
    }
}