using UnityEngine;
using System.Collections.Generic;

public class Evenement1 : Evenement 
{
    public Evenement1(List<Condition> conditions) : base(1,1, conditions, "La boire", "La jeter", "Canette oubliée", "Vous retrouvez une canette énergétique bombée derrière votre bureau pendant vos révisions","Une énergie nouvelle vous envahit +10 énergie","Vous décidez que ça n'en vaut pas le coup")
    {
        
    }

    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Personnage>().augmenterEnergieActuelle(10);
    }

    public override void realiserChoix2()
    {
        //rien
    }
}