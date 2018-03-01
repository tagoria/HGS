using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement10_Conference : EvenementDeuxChoix {
    // id, proba, conditions, texteChoix1, texteChoix2, Titre, Description, DescriptionChoix1, Description Choix2

    public Evenement10_Conference(List<Condition> conditions) : base((int)EvenementsEnum.Conference, 5,
        conditions, "Oui", "Non","Conférence", 
        "Vous êtes convié à une conférence sur la Cyber-sécurité. Souhaitez-vous y aller ?",
        generateCreneau(8,9),
        "La séance fut instructive, saviez-vous que la première défense contre les cyberattaques est de fermer son bureau à clef ? Malin.",
        "La séance est facultative, ça tombe bien vous n'y allez pas")
    {
    }
    public static readonly int CONFERENCE_ASSISTE = 0;
    public static readonly int CONFERENCE_PAS_ASSISTE = 1;

    public override void realiserChoix1()
    {
        Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(1);
        Personnage.instance.diminuerEnergieActuelle(10);
        Horloge.instance.addToHistorique(new EventResult(this,CONFERENCE_ASSISTE));
    }

    public override void realiserChoix2()
    {
        // Nothing
        this.addResultatToHistorique(CONFERENCE_PAS_ASSISTE);
    }
}
