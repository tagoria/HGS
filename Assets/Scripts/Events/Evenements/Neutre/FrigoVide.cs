using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Condition sur la probabilité selon perk Glouton, non réalisée...

public class FrigoVide : EvenementUnSeulChoix
{
    public FrigoVide() : base((int)EvenementsEnum.FrigoVide,(int)ProbaEnum.FrigoVide,
        generateConditions(new HasStatusCondition(StatusEnum.JourFerie, false)),
        choix1:"Ok", 
        titre:"Oups, le frigo est vide", 
        texte: "Il reste à peine un pot de sauce mi-entamé. Votre estomac commence à se plaindre, il est temps de faire les courses", 
        creneau: generateCreneau(9))
    {
    }

    public static readonly int FRIGO_REMPLI = 1;

    public override void realiserChoix1()
    {
        Personnage.instance.diminuerEnergieActuelle(25);
        // addResultatToHistorique(FRIGO_REMPLI);     Est-ce nécessaire d'enregistrer une telle action ? 
        Horloge.instance.avancerDePlusierusCreneauxEnEtantOccupe(1);
    }
}
