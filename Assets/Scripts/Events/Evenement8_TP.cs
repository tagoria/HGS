using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement8_TP : Evenement{

    // id, proba, conditions, texteChoix1, texteChoix2, Description, DescriptionChoix1, Description Choix2

    public Evenement8_TP(List<Condition> conditions) : base(8, 20, conditions, "Tout à fait","Désolé, mais non","TP", "Vous avez cours de Travaux pratiques, ce serait dommage de ne pas y aller, pas vrai ?","Le Tp d'aujourd'hui est Chimie, vous truquez vos volumes équivalents et demandez au professeur pourquoi la question 1, pourquoi la question 3... Cela vous prend 4h.", "Vous séchez les cours, votre cerveau perd un peu de muscle")
    {
    }


    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Horloge>().setCreneauActuel(8);
        Component.FindObjectOfType<Personnage>().diminuerEnergieActuelle(15);
        Component.FindObjectOfType<Personnage>().augmenterTravailActuel(10);
    }

    public override void realiserChoix2()
    {
  
        Component.FindObjectOfType<Personnage>().diminuerTravailActuel(5);
    }
}


