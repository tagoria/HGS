using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement14_Faluche : Evenement {

    private static int probaFaluche = 10;
    //if ( ){} mettre conditions sur les Perk 

    public Evenement14_Faluche(List<Condition> conditions) : base(14,probaFaluche, conditions, "Une Rince-cochon, patron", "Non", "La Faluche", " Vous êtes cordialement invité à vous reposer à la Faluche, y aller ?", "Bière et saucissons en mains, vous discutez sérieusement sur l'avenir de la poubelle connectée. Les gens vous apprécient et vous aussi, vous vous appréciez. Ce fut très sympa.", "Vous restez chez vous.")
    {
    }

    public override void realiserChoix1()
    {
        if (Component.FindObjectOfType<Horloge>().getCreneauActuel() == 8) { Component.FindObjectOfType<Horloge>().setCreneauActuel(9); }
        if (Component.FindObjectOfType<Horloge>().getCreneauActuel() == 9) { Component.FindObjectOfType<Horloge>().setCreneauActuel(10); }
        Component.FindObjectOfType<Personnage>().diminuerEnergieActuelle(10);
        Component.FindObjectOfType<Personnage>().augmenterSocialActuel(10);
    }

    public override void realiserChoix2()
    {
        Component.FindObjectOfType<Personnage>().diminuerSocialActuel(4);
    }

 
}
