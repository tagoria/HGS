﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EvenementCours : Evenement
{
    // id, proba, conditions, texteChoix1, texteChoix2, Titre, Description, DescriptionChoix1, Description Choix2
    public EvenementCours( List<Condition> conditions) : base(3, 5, conditions, "oui", "non", "Cours", "aller en cours?", "Vous allez en cours", "Vous allez pas en cours")
    {
    }
    //l'evenement se produit sur les créneuax 4 et 5 uniquement si il ne s'est pas produit la veille
    public override void realiserChoix1()
    {
        
    }

    public override void realiserChoix2()
    {
        
    }
}