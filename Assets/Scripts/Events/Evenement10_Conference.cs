using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement10_Conference : Evenement {
    // id, proba, conditions, texteChoix1, texteChoix2, Titre, Description, DescriptionChoix1, Description Choix2

    public Evenement10_Conference(List<Condition> conditions) : base(10, 5, conditions, "Oui", "Non","Conférence", "Vous êtes convié à une conférence sur la Cyber-sécurité. Souhaitez-vous y aller ?", "La séance fut instructive, saviez-vous que la première défense contre les cyberattaques est de fermer son bureau à clef ? Malin.", "La séance est facultative, ça tombe bien vous n'y allez pas")
    {
    }


    public override void realiserChoix1()
    {
        Component.FindObjectOfType<Horloge>().setCreneauActuel(10);
        Component.FindObjectOfType<Personnage>().diminuerEnergieActuelle(10);
    }

    public override void realiserChoix2()
    {
        // Nothing
    }
}
